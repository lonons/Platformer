using UnityEngine;

namespace Platformer
{
    public class PlayerController 
    {
        
        #region FIELDS

        private AnimationConfig _config;
        private SpriteAnimatorController _playerAnimator;
        private ContactPooler _contactPooler;
        private LevelObjectView _playerView;

        private Transform _playerT;
        private Rigidbody2D _rb;
        
        private float _xAxisInput;
        private bool _isJump;
        
        private float _walkSpeed = 150f;
        private float _animationSpeed = 10f;
        private float _movingTresghold = 0.1f;

        private readonly Vector3 _leftScale = new Vector3(-1, 1, 1);
        private readonly Vector3 _rightScale = new Vector3(1, 1, 1);

        private bool _isMoving;

        private float _jumpForce = 9f;
        private float _jumpTrashHold = 1f;
        private float _yVelocity = 0;
        private float _xVelosity = 0;

        private int _health = 100;
        #endregion

        #region CONSTRUCTOR

        public PlayerController(InteractiveObjectView player)
        {
            _config = Resources.Load<AnimationConfig>("SpriteAnimCfg");
            _playerAnimator = new SpriteAnimatorController(_config);
            _playerAnimator.StartAnimation(player._spriteRenderer, AnimState.Run, true, _animationSpeed);
            _playerView = player;
            _playerT = player.transform;
            
            _rb = _playerView._rb;
            _contactPooler = new ContactPooler(_playerView._colider);

            player.TakeDamage += TakeBullet;
        }

        #endregion

        #region METHODS

        private void MoveTowards()
        {
            _xVelosity = Time.fixedDeltaTime * _walkSpeed * (_xAxisInput < 0 ? -1 : 1);
            _rb.velocity = new Vector2(_xVelosity, _yVelocity);
            _playerT.localScale = _xAxisInput < 0 ? _leftScale : _rightScale;
        }

        public void Update()
        {
            if (_health <= 0)
            {
                _health = 0;
                _playerView._spriteRenderer.enabled = false;
            }
            _playerAnimator.Update();
            _contactPooler.Update();
            _xAxisInput = Input.GetAxis("Horizontal");
            _isJump = Input.GetAxis("Vertical") > 0;
            _yVelocity = _rb.velocity.y;
            _isMoving = Mathf.Abs(_xAxisInput) > _movingTresghold;
            _playerAnimator.StartAnimation(_playerView._spriteRenderer,_isMoving?AnimState.Run:AnimState.Idle,true,_animationSpeed);
            
            if (_isMoving)
            {
                MoveTowards();
            }
            else
            {
                _xVelosity = 0;
                _rb.velocity =  new Vector2(_xVelosity,_rb.velocity.y);
            }
            if (_contactPooler.IsGrounded)
            {
                if (_isJump && _yVelocity <= _jumpTrashHold)
                {
                    _rb.AddForce(Vector2.up*_jumpForce, ForceMode2D.Impulse);
                }
            }
            else
            {
                if (Mathf.Abs(_yVelocity) > _jumpTrashHold)
                {
                    _playerAnimator.StartAnimation(_playerView._spriteRenderer,AnimState.Jump,true,_animationSpeed);
                }
            }
        }

        public void TakeBullet(BulletView bulletView)
        {
            _health -= bulletView.DamagePoint;
        }

        #endregion
     
    }
}
