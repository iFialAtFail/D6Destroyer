using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Policy;

public class SetTransformToScreenPercentage : MonoBehaviour {

    public Camera screenCamera;
    public Transform objectToMove;
    public bool debug = false;

    [Range(0,1)]
    public float screenPercentageFromBottom = 0f;

    [Range(0, 1)]
    public float screenPercentageFromLeft = .5f;

    public void Set(Transform itemToMove){
        Vector3 location = new Vector3(screenCamera.pixelWidth * screenPercentageFromLeft,
                                       screenCamera.pixelHeight * screenPercentageFromBottom, 
                                       -screenCamera.transform.position.z);
        itemToMove.position = screenCamera.ScreenToWorldPoint(location);
    }

	private void Start()
	{
        Set(objectToMove);
	}

	private void Update()
	{
        if (debug){
            Set(objectToMove);
        }
	}
}
