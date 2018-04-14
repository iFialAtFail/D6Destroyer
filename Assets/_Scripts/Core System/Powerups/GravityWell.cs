using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoboRyanTron.Unite2017.Variables;

public class GravityWell : TimedPowerup
{

    public TargetRuntimeSet targetSet;
    public FloatVariable drag;

    public float gravityForce = -100f;
    public float gravityWellRadius = 25;
    public ForceMode gravForceMode;

	public override void StartPowerup()
	{
        powEnabled = true;
        StartGravityWell();
	}

	public override void StopPowerup()
	{
        powEnabled = false;
        StopGravityWell();
	}

	public void StartGravityWell()
    {
        if (targetSet.Items.Count > 0)
        {
            for (int i = 0; i < targetSet.Items.Count; i++)
            {
                targetSet.Items[i].Rigidbody.useGravity = false;
            }
        }

    }

    public void StopGravityWell()
    {
        for (int i = 0; i < targetSet.Items.Count; i++)
        {
            targetSet.Items[i].Rigidbody.useGravity = true;
            targetSet.Items[i].Rigidbody.drag = drag.Value;
        }
    }

	public void ToggleGravityWell()
    {
        if (powEnabled)
        {
            StopGravityWell();
        }
        else
        {
            StartGravityWell();
        }
    }

	public override void UpdateStep()
	{
        gravityFrameStep();
	}

	public void gravityFrameStep()
    {
        if (targetSet.Items.Count < 1)
        {
            return;
        }

        //Make sure all targets are not using gravity, TODO Consider moving this to gameeventListener
        for (int i = 0; i < targetSet.Items.Count; i++)
        {
            targetSet.Items[i].Rigidbody.useGravity = false;
            targetSet.Items[i].Rigidbody.drag = 0;

        }
        //add gravity well effect to targets.
        for (int i = 0; i < targetSet.Items.Count; i++)
        {
            targetSet.Items[i].Rigidbody.AddExplosionForce(gravityForce, this.transform.position, gravityWellRadius, 0, gravForceMode);
        }
    }

}
