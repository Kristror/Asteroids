using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Utilities
{
    public class BorderController : IFixedTickable
    {
        private const float BORDER_OFFSET = 0.5f;

        private List<Transform> _movingObjectsList;

        private Camera _camera;

        private float _leftBorder;
        private float _rightBorder;
        private float _topBorder;
        private float _bottomBorder;

        public BorderController(Camera camera)
        {
            _movingObjectsList = new List<Transform>();
            _camera = camera;
            CalculateScreenBounds();
        }

        public void FixedTick()
        {
            foreach (Transform obj in _movingObjectsList) 
            {
                if (CheckIfObjectOnBorder(obj.position))
                {
                    obj.position = MoveObjectOnOtherSide(obj.position);
                }
            }
        }

        public void TrackObject(Transform transform)
        {
            _movingObjectsList.Add(transform);
        }
        
        public void StopTrackingObject(Transform transform)
        {
            _movingObjectsList.Remove(transform);
        }

        private void CalculateScreenBounds()
        {
            Vector3 bottomLeft = _camera.ViewportToWorldPoint(Vector3.zero);
            Vector3 topRight = _camera.ViewportToWorldPoint(new Vector3(1, 1, 0));

            _leftBorder = bottomLeft.x - BORDER_OFFSET;
            _rightBorder = topRight.x + BORDER_OFFSET;
            _bottomBorder = bottomLeft.y - BORDER_OFFSET;
            _topBorder = topRight.y + BORDER_OFFSET;
        }

        private bool CheckIfObjectOnBorder(Vector2 objectPosition)
        {
            if ((objectPosition.x < _leftBorder) || (objectPosition.x > _rightBorder))
            {              
                return true;
            }

            if ((objectPosition.y < _bottomBorder) || (objectPosition.y > _topBorder))
            {
                return true;
            }

            return false;
        }

        private Vector2 MoveObjectOnOtherSide(Vector2 objectPosition)
        {
            Vector3 newObjectPosition = objectPosition;

            if (objectPosition.x < _leftBorder)
            {
                newObjectPosition.x = _rightBorder;
                return newObjectPosition;
            }
            else if (objectPosition.x > _rightBorder)
            {
                newObjectPosition.x = _leftBorder;
                return newObjectPosition;
            }

            if (objectPosition.y < _bottomBorder)
            {
                newObjectPosition.y = _topBorder;
                return newObjectPosition;
            }
            else if (objectPosition.y > _topBorder)
            {
                newObjectPosition.y = _bottomBorder;
                return newObjectPosition;
            }

            return newObjectPosition;
        }
    }
}