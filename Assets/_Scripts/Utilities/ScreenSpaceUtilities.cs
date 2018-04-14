using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSpaceUtilities : MonoBehaviour
{
    /// <summary>
    /// Gets the left bound coordinate.
    /// </summary>
    /// <returns>The left bound coordinate.</returns>
    public static Vector3 GetLeftBoundCoordinate()
    {
        return Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight / 2, -Camera.main.transform.position.z));
    }

    /// <summary>
    /// Gets the right bound coordinate.
    /// </summary>
    /// <returns>The right bound coordinate.</returns>
    public static Vector3 GetRightBoundCoordinate()
    {
        return Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight / 2, -Camera.main.transform.position.z));
    }

    /// <summary>
    /// Gets the top bound coordinate.
    /// </summary>
    /// <returns>The top bound coordinate.</returns>
    public static Vector3 GetTopBoundCoordinate()
    {
        return Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight, -Camera.main.transform.position.z));
    }

    /// <summary>
    /// Gets the bottom bound coordinate.
    /// </summary>
    /// <returns>The bottom bound coordinate.</returns>
    public static Vector3 GetBottomBoundCoordinate()
    {
        return Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth / 2, 0, -Camera.main.transform.position.z));
    }

    /// <summary>
    /// Places the gameobject transform at screen space bound.
    /// </summary>
    /// <param name="bound">Bound.</param>
    public static void PlaceGameobjectAtBound(Bound bound, GameObject obj, float offset = 0)
    {
        switch (bound)
        {
            case Bound.bottom:
                obj.transform.position = ScreenSpaceUtilities.GetBottomBoundCoordinate() + new Vector3(0, -offset, 0);
                break;
            case Bound.top:
                obj.transform.position = ScreenSpaceUtilities.GetTopBoundCoordinate() + new Vector3(0, offset, 0);
                break;
            case Bound.left:
                obj.transform.position = ScreenSpaceUtilities.GetLeftBoundCoordinate() + new Vector3(-offset, 0, 0);
                break;
            case Bound.right:
                obj.transform.position = ScreenSpaceUtilities.GetRightBoundCoordinate() + new Vector3(offset, 0, 0);
                break;
            default:
                break;
        }
    }

}

public enum Bound{
    bottom,
    top,
    left,
    right
}
