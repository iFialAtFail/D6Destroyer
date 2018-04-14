using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{


    public GameObject spawnObject;
    public bool shouldSpawnRepeating = true;
    public float interval = .5f;

    // Use this for initialization
    void Start()
    {
        if (spawnObject != null)
        {
            StartCoroutine(SpawnRepeating(interval));
        }
        else
        {
            Debug.LogError("Assign an object to spawn.");
        }
    }

    /// <summary>
    /// Spawn the gameobject assigned to the spawner script, assigned to the spawner in the
    /// hierarchy and located at the spawner location. Optional arguments allow for varied spawn locations
    /// </summary>
    public void Spawn(bool randomVariation = false, float variationAmount = 0)
    {
        if (spawnObject == null)
        {
            throw new System.Exception("Must assign gameobject to spawner in the inspector.");
        }
        Vector3 spawnPosition =
            randomVariation ? (transform.position + new Vector3(Random.Range(-variationAmount, variationAmount), 0f)) : transform.position;

        Instantiate(spawnObject, spawnPosition, Quaternion.identity, this.transform);
    }

    /// <summary>
    /// Spawn a game object of your choice. Spawns object at and parents to this spawner
    /// game object.
    /// </summary>
    /// <param name="obj"></param>
    public void Spawn(GameObject obj)
    {
        Instantiate(obj, transform.position, Quaternion.identity, this.transform);
    }

    public IEnumerator SpawnRepeating(float interval)
    {
        while (shouldSpawnRepeating)
        {
            yield return new WaitForSeconds(interval);
            Spawn();
        }

    }

    private void OnDestroy()
    {
        StopCoroutine(SpawnRepeating(interval));
    }
}
