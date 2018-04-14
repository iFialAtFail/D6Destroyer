using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DynamicSpawnLocationManager : MonoBehaviour
{
    public GameObject[] spawners;
    // Use this for initialization
    void Start()
    {
        PlaceGameobjectsHorizontally(spawners, Camera.main.ScreenToWorldPoint(new Vector3(0,Camera.main.pixelHeight)).y, 0);
    }

    public void PlaceGameobjectsHorizontally(GameObject[] gameObjects, float yPos, float zPos = 0)
    {
        Vector3 startPosition = Camera.main.ScreenToWorldPoint(new Vector3(0, 0));
        Vector3 endPosition = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0));
        float distanceToTravel = Vector3.Distance(endPosition, startPosition);
        float segment = distanceToTravel / (float)(spawners.Length + 1f);

        for (int i = 0; i < spawners.Length; i++)
        {
            gameObjects[i].transform.position = new Vector3(startPosition.x + (segment * (i + 1)), yPos, zPos);
        }
    }
}
