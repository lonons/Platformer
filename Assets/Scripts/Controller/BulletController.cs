using UnityEngine;

namespace Platformer
{
    public class BulletController
    {
        private Vector3 _velocity;
        private BulletView _view;

        public BulletController(BulletView bulletView)
        {
            _view = bulletView;
            Active(false);
        }

        #region METHODS

        public void Active(bool val)
        {
            _view.gameObject.SetActive(val);
        }

        private void SetVelocity(Vector3 velocity)
        {
            _velocity = velocity;
            float _angle = Vector3.Angle(Vector3.left, _velocity);
            Vector3 _axis = Vector3.Cross(Vector3.left, _velocity);
            _view.transform.rotation = Quaternion.AngleAxis(_angle,_axis);
        }

        public void Trow(Vector3 position, Vector3 velocity)
        {
            _view._transform.position = position;
            SetVelocity(velocity);
            _view._rb.velocity = Vector2.zero;
            _view._rb.angularVelocity = 0;
            Active(true);
            
            _view._rb.AddForce(velocity,ForceMode2D.Impulse);
        }
        #endregion
       
    }

}
