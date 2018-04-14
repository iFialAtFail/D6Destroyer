using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{

    public GameObject leftWall;
    public GameObject rightWall;
    public GameObject topWall;
    public GameObject bottomWall;

    public float offset = 0f;

    // Use this for initialization
    void Start()
    {
        if (leftWall != null) ScreenSpaceUtilities.PlaceGameobjectAtBound(Bound.left, leftWall, offset);
        if (rightWall != null) ScreenSpaceUtilities.PlaceGameobjectAtBound(Bound.right, rightWall, offset);
        if (topWall != null) ScreenSpaceUtilities.PlaceGameobjectAtBound(Bound.top, topWall, offset);
        if (bottomWall != null) ScreenSpaceUtilities.PlaceGameobjectAtBound(Bound.bottom, bottomWall, offset);
    }
}
