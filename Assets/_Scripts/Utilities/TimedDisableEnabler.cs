using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoboRyanTron.Unite2017.Variables;

public class TimedDisableEnabler : MonoBehaviour {

    public GameObject objectToEnableOrDisable;
    public FloatVariable timeToDisableOrEnable;

    public IEnumerator DisableThenEnableRoutine(){
        objectToEnableOrDisable.SetActive(false);
        yield return new WaitForSeconds(timeToDisableOrEnable.Value);
        objectToEnableOrDisable.SetActive(true);
    }

    public IEnumerator EnableThenDisableRoutine()
    {
        objectToEnableOrDisable.SetActive(true);
        yield return new WaitForSeconds(timeToDisableOrEnable.Value);
        objectToEnableOrDisable.SetActive(false);
    }

    public void EnableThenDisable(){
        StartCoroutine(EnableThenDisableRoutine());
    }

    public void DisableThenEnable(){
        StartCoroutine(DisableThenEnableRoutine());
    }
}
