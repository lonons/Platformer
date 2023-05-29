using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

namespace Platformer
{
    public class Main : MonoBehaviour
    {
        #region SERIALIZE FIELDS

        [SerializeField]
        private InteractiveObjectView _playerView;
        [SerializeField]
        private CannonView _cannonView;
        [SerializeField]
        private AIConfig _config;
        [SerializeField]
        private EnemyView _enemyView;
        
        #endregion

        #region FIELDS

        private PlayerController _playerController;
        private CannonController _canonController;
        private EmitterController _emitterController;
        private SimplePatrolAI _simplePatrolAI;
        private ProtectorAI _protectorAI;
        private ProtectedZone _protectedZone;
        
        [Header("Protector AI")]
        [SerializeField] private AIDestinationSetter _protectorAIDestinationSetter;
        [SerializeField] private AIPatrolPath _protectorAIPatrolPath;
        [SerializeField] private LevelObjectTrigger _protectedZoneTrigger;
        [SerializeField] private Transform[] _protectorWaypoints;

        #endregion

        #region UNITY

        void Awake()
        {
            _playerController = new PlayerController(_playerView);
            _canonController = new CannonController(_cannonView._muzzleT, _playerView.transform);
            _emitterController = new EmitterController(_cannonView._bullets, _cannonView._emitterT);
         //   _simplePatrolAI = new SimplePatrolAI(_enemyView, new SimplePatrolAIModel(_config));
            
            _protectorAI = new ProtectorAI(_playerView, new PatrolAIModel(_protectorWaypoints), _protectorAIDestinationSetter, _protectorAIPatrolPath);
            _protectorAI.Init();
      
            _protectedZone = new ProtectedZone(_protectedZoneTrigger, new List<IProtector>{ _protectorAI });
            _protectedZone.Init();
        }

        void Update()
        {
            _playerController.Update();
            _canonController.Update();
            _emitterController.Update();
            
        }

        private void FixedUpdate()
        {
            //_simplePatrolAI.FixedUpdate();
        }

        private void OnDestroy()
        {
            _protectorAI.Deinit();
            _protectedZone.DeInit();
        }
        
        #endregion
        
    }

}
