using UnityEngine;

public static class ScreenSize
{
    static Camera mainCamera = Camera.main;

    public static Vector2 GetScreenSizeInUnits()
    {

        float screenHeightInUnits = mainCamera.orthographicSize * 2;

        float screenWidthInUnits = screenHeightInUnits * mainCamera.aspect;

        return new Vector2(screenWidthInUnits, screenHeightInUnits);
    }
}