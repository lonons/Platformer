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

        #endregion

        #region FIELDS

        private PlayerController _playerController;

        #endregion

        #region UNITY

        void Awake()
        {
            _playerController = new PlayerController(_playerView);
        }

        void Update()
        {
            _playerController.Update();
        }

        #endregion
        
    }

}
