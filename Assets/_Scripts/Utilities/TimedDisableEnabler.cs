using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDisableEnabler : MonoBehaviour {

    public GameObject objectToEnableOrDisable;
    public float timeToDisableOrEnable = 15f;

    public IEnumerator DisableThenEnableRoutine(){
        objectToEnableOrDisable.SetActive(false);
        yield return new WaitForSeconds(timeToDisableOrEnable);
        objectToEnableOrDisable.SetActive(true);
    }

    public IEnumerator EnableThenDisableRoutine()
    {
        objectToEnableOrDisable.SetActive(true);
        yield return new WaitForSeconds(timeToDisableOrEnable);
        objectToEnableOrDisable.SetActive(false);
    }

    public void EnableThenDisable(){
        StartCoroutine(EnableThenDisableRoutine());
    }

    public void DisableThenEnable(){
        StartCoroutine(DisableThenEnableRoutine());
    }
}
