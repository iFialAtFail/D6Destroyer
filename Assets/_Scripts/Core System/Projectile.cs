using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public ProjectileRuntimeSet Set;
    //private PowerupManager manager;
    private bool homingActive;

    private void Awake()
    {
        Set.Add(this);
    }

    private void OnDestroy()
    {
        Set.Remove(this);
    }

    public Rigidbody Rigidbody;

    public void SetHoming(bool active)
    {
        this.homingActive = active;
    }

    public static Vector3 CalculateRedirectedVelocity(Vector3 initialVelocity, Vector3 currentPosition, Vector3 targetPosition)
    {
        var magnitude = initialVelocity.magnitude;
        var direction = (targetPosition - currentPosition).normalized;
        return direction * magnitude;
    }

}
