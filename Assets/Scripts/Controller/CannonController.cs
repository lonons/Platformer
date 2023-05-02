using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class CannonController
    {
        private Transform _muzzleT;
        private Transform _targetT;

        private Vector3 _dir;
        private Vector3 _axis;
        private float _angle;

        public CannonController(Transform muzzle, Transform target)
        {
            _muzzleT = muzzle;
            _targetT = target;
        }

        public void Update()
        {
            _dir = _targetT.position - _muzzleT.position;
            _angle = Vector3.Angle(Vector3.down, _dir);
            _axis = Vector3.Cross(Vector3.down, _dir);
            
            _muzzleT.transform.rotation = Quaternion.AngleAxis(_angle,_axis);
        }
    }

}
