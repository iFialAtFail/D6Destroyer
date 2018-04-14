using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialRotationKick : MonoBehaviour {

    public Rigidbody rb;
    public float multiplier = 1f;

	// Use this for initialization
	void Start () {
        var torque = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        torque *= multiplier;
		rb.AddTorque(torque, ForceMode.Impulse);
	}
	
}
