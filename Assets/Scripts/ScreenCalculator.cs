using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenCalculator
{
    static float left;
    static float right;
    static float lower;
    static float upper;
    /// <summary>
    /// coordinate of the left of the screen
    /// </summary>
    public static float Left
    {
        get
        {
            return left;
        }
    }
    /// <summary>
    /// coordinate of the right of the screen
    /// </summary>
    public static float Right
    {
        get
        {
            return right;
        }
    }
    /// <summary>
    /// coordinate of the upper of the screen
    /// </summary>
    public static float Upper
    {
        get
        {
            return upper;
        }
    }
    /// <summary>
    /// coordinate of the lower of the screen
    /// </summary>
    public static float Lower
    {
        get
        {
            return lower;
        }
    }
    public static void Init()
    {
        float screenZaxis = -Camera.main.transform.position.z;
        Vector3 lowerLeftCorner = new Vector3(0, 0, screenZaxis);
        Vector3 rightUpperCorner = new Vector3(Screen.width, Screen.height, screenZaxis);

        Vector3 lowerLeftCornerGameWorld = Camera.main.ScreenToWorldPoint(lowerLeftCorner);
        Vector3 rightUpperCornerGameWorld = Camera.main.ScreenToWorldPoint(rightUpperCorner);

        left = lowerLeftCornerGameWorld.x;
        right = rightUpperCornerGameWorld.x;
        upper = rightUpperCornerGameWorld.y;
        lower = lowerLeftCornerGameWorld.y;
    }
}
