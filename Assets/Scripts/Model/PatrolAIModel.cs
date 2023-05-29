using UnityEngine;

namespace Platformer
{
    public class PatrolAIModel
    {
        private Transform[] _wayPoints;
        private int _currentPointIndex;
        
        public PatrolAIModel(Transform[] wayPoints)
        {
            _wayPoints = wayPoints;
            _currentPointIndex = 0;
        }

        public Transform GetNextWayPoint()
        {
            if (_wayPoints == null)
                return null;
            _currentPointIndex = (_currentPointIndex + 1) % _wayPoints.Length;
            return _wayPoints[_currentPointIndex];
        }

        public Transform GetClosestTarget(Vector2 fromPosition)
        {
            if (_wayPoints == null)
                return null;
            var closestIndex = 0;
            var closestDistance = float.PositiveInfinity;
            for (var i = 0; i < _wayPoints.Length; i++)
            {
                var distance = Vector2.Distance(fromPosition, _wayPoints[i].position);
                if (closestDistance > distance)
                {
                    closestDistance = distance;
                    closestIndex = i;
                }
            }

            _currentPointIndex = closestIndex;
            return _wayPoints[_currentPointIndex];
        }
    }
}