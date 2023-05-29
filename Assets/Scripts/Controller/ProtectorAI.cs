using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

namespace Platformer
{
    public class ProtectorAI : IProtector 
    {
    
        private readonly InteractiveObjectView _view;
        private readonly PatrolAIModel _model;
        private readonly AIDestinationSetter _destinationSetter;
        private readonly AIPatrolPath _patrolPath;
  
        private bool _isPatrolling;
 
        public ProtectorAI(InteractiveObjectView view, PatrolAIModel model, AIDestinationSetter destinationSetter, AIPatrolPath patrolPath)
        {
            _view = view;
            _model = model;
            _destinationSetter = destinationSetter;
            _patrolPath = patrolPath;
        }

        public void Init()
        {
            _destinationSetter.target = _model.GetNextWayPoint();
            _isPatrolling = true;
            _patrolPath.TargetReached += OnTargetReached;
        }

        public void Deinit()
        {
            _patrolPath.TargetReached -= OnTargetReached;
        }
    
        private void OnTargetReached()
        {
            _destinationSetter.target = _isPatrolling
                ? _model.GetNextWayPoint()
                : _model.GetClosestTarget(_view.transform.position);
        }
  
        public void StartProtection(GameObject invader)
        {
            _isPatrolling = false;
            _destinationSetter.target = invader.transform;
        }

        public void FinishProtection(GameObject invader)
        {
            _isPatrolling = true;
            _destinationSetter.target = _model.GetClosestTarget(_view.transform.position);
        }
        
    }
}
