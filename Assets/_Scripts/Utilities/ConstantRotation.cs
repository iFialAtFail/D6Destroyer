using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantRotation : MonoBehaviour {

    public bool shouldRotate = true;
    public Transform objectToRotate;
    public float anglePerSecond = 5;
    public Vector3 direction;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (shouldRotate){
            if (objectToRotate == null){
                objectToRotate = transform;
            }
            objectToRotate.RotateAroundLocal(direction, anglePerSecond * Time.deltaTime);

        }
	}
}
