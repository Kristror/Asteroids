using UnityEngine;

public static class ScreenSize
{
    public static Vector2 GetScreenSizeInUnits()
    {
        Camera mainCamera = Camera.main;

        float screenHeightInUnits = mainCamera.orthographicSize * 2;

        float screenWidthInUnits = screenHeightInUnits * mainCamera.aspect;

        return new Vector2(screenWidthInUnits, screenHeightInUnits);
    }
}