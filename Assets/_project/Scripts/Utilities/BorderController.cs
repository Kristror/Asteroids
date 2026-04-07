using UnityEngine;

namespace Utilites
{
    public class BorderController
    {
        private const float _borderOffSet = 0.5f;

        private Camera _camera;

        private float _leftBorder;
        private float _rightBorder;
        private float _topBorder;
        private float _bottomBorder;

        public BorderController(Camera camera)
        {
            _camera = camera;
            CalculateScreenBounds();
        }

        public Vector2 CheckIfObjectOnBorder(Vector2 objectPosition)
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

            return Vector2.zero;
        }

        private void CalculateScreenBounds()
        {
            Vector3 bottomLeft = _camera.ViewportToWorldPoint(Vector3.zero);
            Vector3 topRight = _camera.ViewportToWorldPoint(new Vector3(1, 1, 0));

            _leftBorder = bottomLeft.x - _borderOffSet;
            _rightBorder = topRight.x + _borderOffSet;
            _bottomBorder = bottomLeft.y - _borderOffSet;
            _topBorder = topRight.y + _borderOffSet;
        }
    }
}