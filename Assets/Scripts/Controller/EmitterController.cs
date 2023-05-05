
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace Platformer
{
    public class EmitterController
    {
        private List<BulletController> _bulletControllers = new List<BulletController>();
        private Transform _tr;

        private int _index;
        private float _timeTillNextBull;
        private float _startSpeed = 15f;
        private float _delay = 1f;
     
        public  EmitterController(List<BulletView> bulletViews,Transform emitterTr)
        {
            _tr = emitterTr;
            foreach (BulletView bulletView in bulletViews)
            {
                _bulletControllers.Add(new BulletController(bulletView));
            }
        }
        public void Update()
        {
            if (_timeTillNextBull > 0)
            {
                _bulletControllers[_index].Active(false);
                _timeTillNextBull -= Time.deltaTime;
            }
            else
            {
                _timeTillNextBull = _delay;
                _bulletControllers[_index].Trow(_tr.position, -_tr.up*_startSpeed);
                _index++;
                if (_index >= _bulletControllers.Count)
                {
                    _index = 0;
                }
            }
        }
    }

}

