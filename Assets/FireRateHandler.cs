using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Policy;
using RoboRyanTron.Unite2017.Variables;

public class FireRateHandler : MonoBehaviour
{

    public FloatVariable fireRate;
    public float rateModifier = 1.5f;

    public void SpeedUpFireRate()
    {
        fireRate.Value /= rateModifier;
    }

    public void SlowDownAFireRate()
    {
        fireRate.Value *= rateModifier;
    }

}
