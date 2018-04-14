using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Target))]
public class DeathEffect : MonoBehaviour {

    public Target target;
    public GameObject deathParticleEffect;

	// Use this for initialization
	void Start () {
        if (target == null){
            target = GetComponent<Target>();
        }
        target.TargetDiedEvent += (sender, e) => {
            Instantiate(deathParticleEffect, this.transform.position, this.transform.rotation);//Quaternion.EulerAngles(Vector3.back));//
        };
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
