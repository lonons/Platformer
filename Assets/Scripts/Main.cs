using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class Main : MonoBehaviour
    {
        #region SERIALIZE FIELDS

        [SerializeField]
        private LevelObjectView _playerView;
        [SerializeField]
        private CannonView _cannonView;
        #endregion

        #region FIELDS

        private PlayerController _playerController;
        private CannonController _canonController;
        
        #endregion

        #region UNITY

        void Awake()
        {
            _playerController = new PlayerController(_playerView);
            _canonController = new CannonController(_cannonView._muzzleT, _playerView.transform);
        }

        void Update()
        {
            _playerController.Update();
            _canonController.Update();
        }

        #endregion
        
    }

}
