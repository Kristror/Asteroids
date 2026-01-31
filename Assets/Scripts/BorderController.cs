using UnityEngine;

public static class BorderController
{
    private static Camera _camera;

    private static float _borderOffSet = 0.5f;

    private static float leftBound;
    private static float rightBound;
    private static float topBound;
    private static float bottomBound;

    private static void CalculateScreenBounds()
    {
        _camera = Camera.main;

        Vector3 bottomLeft = _camera.ViewportToWorldPoint(Vector3.zero);
        Vector3 topRight = _camera.ViewportToWorldPoint(new Vector3(1, 1, 0));

        leftBound = bottomLeft.x - _borderOffSet;
        rightBound = topRight.x + _borderOffSet;
        bottomBound = bottomLeft.y - _borderOffSet;
        topBound = topRight.y + _borderOffSet;
    }

    public static Vector2 CheckIfObjectOnBorder(Vector2 objectPosition)
    {
        if (_camera == null) 
        {
            CalculateScreenBounds();
        }

        Vector3 newObjectPosition = objectPosition;

        if (objectPosition.x < leftBound)
        {
            newObjectPosition.x = rightBound;
            return newObjectPosition;
        }
        else if (objectPosition.x > rightBound)
        {
            newObjectPosition.x = leftBound;
            return newObjectPosition;
        }

        if (objectPosition.y < bottomBound)
        {
            newObjectPosition.y = topBound;
            return newObjectPosition;
        }
        else if (objectPosition.y > topBound)
        {
            newObjectPosition.y = bottomBound;
            return newObjectPosition;
        }

        return Vector2.zero;
    }
}