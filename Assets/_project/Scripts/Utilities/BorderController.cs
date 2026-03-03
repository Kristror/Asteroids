using UnityEngine;

public static class BorderController
{
    private static Camera _camera;

    private static float _borderOffSet = 0.5f;

    private static float _leftBorder;
    private static float _rightBorder;
    private static float _topBorder;
    private static float _bottomBorder;

    private static void CalculateScreenBounds()
    {
        _camera = Camera.main;

        Vector3 bottomLeft = _camera.ViewportToWorldPoint(Vector3.zero);
        Vector3 topRight = _camera.ViewportToWorldPoint(new Vector3(1, 1, 0));

        _leftBorder = bottomLeft.x - _borderOffSet;
        _rightBorder = topRight.x + _borderOffSet;
        _bottomBorder = bottomLeft.y - _borderOffSet;
        _topBorder = topRight.y + _borderOffSet;
    }

    public static Vector2 CheckIfObjectOnBorder(Vector2 objectPosition)
    {
        if (_camera == null) 
        {
            CalculateScreenBounds();
        }

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
}