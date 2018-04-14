using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Pierce handler. Pierce capabilities when monobehaviour is enabled and not when disabled.
/// </summary>
public class PierceHandler : TimedPowerup {

    public TargetRuntimeSet targetSet;

	public override void StartPowerup()
	{
        powEnabled = true;
    }

	public override void StopPowerup()
	{
        powEnabled = false;
        TurnAllTargetTriggersOff();
    }

	public override void UpdateStep()
	{
        HandleUpdateStep();
	}

    private void HandleUpdateStep(){
        //Make sure all targets are in trigger mode to stop collisions.
        foreach (Target target in targetSet.Items)
        {
            if (target.Collider.isTrigger != true)
                target.Collider.isTrigger = true;
        }
    }

    private void TurnAllTargetTriggersOff(){
        foreach (var target in targetSet.Items)
        {
            target.Collider.isTrigger = false;
        }
    }
}
