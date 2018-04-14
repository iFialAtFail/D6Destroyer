using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillzoneManager : MonoBehaviour
{

    public Killzone leftBoundedKillzone;
    public Killzone rightBoundedKillzone;
    public Killzone topBoundedKillzone;
    public Killzone bottomBoundedKillzone;

    public float offset = 2f;

    // Use this for initialization
    void Start()
    {
        if (topBoundedKillzone != null) ScreenSpaceUtilities.PlaceGameobjectAtBound(Bound.top, topBoundedKillzone.gameObject, offset);
        if (bottomBoundedKillzone != null) ScreenSpaceUtilities.PlaceGameobjectAtBound(Bound.bottom, bottomBoundedKillzone.gameObject, offset);
        if (leftBoundedKillzone != null) ScreenSpaceUtilities.PlaceGameobjectAtBound(Bound.left, leftBoundedKillzone.gameObject, offset);
        if (rightBoundedKillzone != null) ScreenSpaceUtilities.PlaceGameobjectAtBound(Bound.right, rightBoundedKillzone.gameObject, offset);
    }

}
