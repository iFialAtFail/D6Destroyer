using RoboRyanTron.Unite2017.Variables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    public FloatVariable shootDelay;
    public IntVariable splitState;
    public Transform safeZone;
    //public IntVariable speedState;
    public GameObject projectile;
    public float speed = 2;

    public float shotDirection = -0.5f;


    private bool shooting = false;

    // Use this for initialization
    void Start()
    {
        if (projectile == null) Debug.LogWarning("Assign a peojectile to " + this.gameObject.name + " gameobject");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && !shooting)
        {
            StartCoroutine(Shoot(splitState.Value));
        }

    }

    public IEnumerator Shoot(int numberOfShots)
    {
        shooting = true;
        Vector3 clickPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (!InSafeZone(clickPoint))
        {
            float angleSplit = Mathf.PI / 32;// Radians
            float bottomAngleLimit = shotDirection * (numberOfShots - 1) * angleSplit; //offset starts at (0.5 * (N-1)) to the left.

            for (int i = 0; i < numberOfShots; i++)
            {
                GameObject go = Instantiate(projectile, new Vector3(clickPoint.x, clickPoint.y, 0), Quaternion.identity);
                Vector3 direction = new Vector3(Mathf.Sin(bottomAngleLimit), Mathf.Cos(bottomAngleLimit), 0);
                bottomAngleLimit += angleSplit;
                go.GetComponent<Rigidbody>().AddForce(direction * speed, ForceMode.VelocityChange);
            }

            yield return new WaitForSeconds(shootDelay.Value);
        }
		shooting = false;
    }

    //Safe zone is considered below the killzone.
    private bool InSafeZone(Vector3 clickPoint){
        if ((clickPoint - safeZone.position).y > 0)
        {
            return false;
        }
        else return true;
    }
}
