using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InitializeIntVariable : MonoBehaviour {

    public IntVariable intVariable;
    public int defaultOnstartValue = 1;

	// Use this for initialization
	void Start () {
        intVariable.Value = defaultOnstartValue;
        //Debug.Log("Int variable of description: " + intVariable.DeveloperDescription + " initialized to " + intVariable.Value + " from Game object: " + gameObject.name);
	}

	private void OnDestroy()
	{
        Start();
	}
}
