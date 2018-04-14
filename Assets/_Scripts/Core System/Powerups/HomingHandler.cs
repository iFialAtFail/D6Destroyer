using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingHandler : TimedPowerup
{
    public TargetRuntimeSet targetSet;
    public ProjectileRuntimeSet projectileSet;

    #region TimedPowerup Implementation

    public override void StartPowerup()
    {
        powEnabled = true;
    }

    public override void StopPowerup()
    {
        powEnabled = false;
    }

    public override void UpdateStep()
    {
        HomingStep();
    }

    #endregion

    protected void HomingStep()
    {
        if (targetSet.Items.Count < 1)
        {
            return;
        }

        Target lowestTarget = null;
        for (int i = 0; i < targetSet.Items.Count; i++)
        {
            if (lowestTarget == null)
                lowestTarget = targetSet.Items[i];
            else
            {
                if (targetSet.Items[i].transform.position.y < lowestTarget.transform.position.y)
                {
                    lowestTarget = targetSet.Items[i];
                }
            }
        }

        if (lowestTarget == null)
        {
            return;
        }

        foreach (var projectile in projectileSet.Items)
        {
            projectile.Rigidbody.velocity = Projectile.CalculateRedirectedVelocity(projectile.Rigidbody.velocity, projectile.transform.position, lowestTarget.transform.position);
        }
    }

}
