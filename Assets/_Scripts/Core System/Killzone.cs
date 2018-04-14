using RoboRyanTron.Unite2017.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killzone : MonoBehaviour
{
    //public Action ObjectDestroyed;
    public string[] tagsToAvoidDestroying = { "Projectile", "Wall" };

    private void OnTriggerEnter(Collider other)
    {
        if (ShouldDestroyObject(other.gameObject))
        {
            var target = other.gameObject.GetComponent<Target>();
            if (target != null){
                ((Target)target).HandleDeath();
            }
            Destroy(other.gameObject);
        }

    }

    private bool ShouldDestroyObject(GameObject other)
    {
        bool shouldDestroy = true;
        foreach (string tag in tagsToAvoidDestroying)
        {
            if (tag == other.tag)
            {
                return false;
            }
        }
        return shouldDestroy;
    }
}
