using System.Collections;
using System.Collections.Generic;
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
        #endregion

        #region FIELDS

        private PlayerController _playerController;
        private CannonController _canonController;
        private EmitterController _emitterController;
        
        #endregion

        #region UNITY

        void Awake()
        {
            _playerController = new PlayerController(_playerView);
            _canonController = new CannonController(_cannonView._muzzleT, _playerView.transform);
            _emitterController = new EmitterController(_cannonView._bullets, _cannonView._emitterT);
        }

        void Update()
        {
            _playerController.Update();
            _canonController.Update();
            _emitterController.Update();
        }

        #endregion
        
    }

}
