using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedPowerup : MonoBehaviour
{

    protected bool powEnabled = false;

    private void Update()
    {
        if (powEnabled)
        {
            UpdateStep();
        }
    }

    public virtual void UpdateStep()
    {
        throw new System.Exception("Child classes need to implement the UpdateStep method.");
    }

    public virtual void OnEnable()
    {
        StartPowerup();
    }

    public virtual void OnDisable()
    {
        StopPowerup();
    }

    public virtual void StartPowerup()
    {
        throw new System.Exception("Child classes need to implement the UpdateStep method.");
    }

    public virtual void StopPowerup()
    {
        throw new System.Exception("Child classes need to implement the UpdateStep method.");
    }



}
