using RoboRyanTron.Unite2017.Variables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRateSetter : MonoBehaviour {

    public FloatVariable fireRate;
    public bool shouldResetOnDestroy = true;

    private float initialValue;

    private void Start()
    {
        initialValue = fireRate.Value;
    }

    private void OnDestroy()
    {
        if (shouldResetOnDestroy)
            fireRate.Value = initialValue;
    }
}
