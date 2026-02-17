using UnityEngine;

public static class ScreenSize
{
    private static Camera mainCamera;
    public static Vector2 GetScreenSizeInUnits()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }

        float screenHeightInUnits = mainCamera.orthographicSize * 2;

        float screenWidthInUnits = screenHeightInUnits * mainCamera.aspect;

        return new Vector2(screenWidthInUnits, screenHeightInUnits);
    }
}