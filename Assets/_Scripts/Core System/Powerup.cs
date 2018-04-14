using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public delegate void PowerupDeathHandler(PowerupState powerupType, Powerup target);


public class Powerup : MonoBehaviour
{
    private bool isColliding = false;
    public List<PowerupElement> powerupElements = new List<PowerupElement>();

    [Tooltip("Lets us choose a specific powerup")]
    public PowerupElement powerupStateType;


    public PowerupElement ChooseRandomPowerup()
    {
        int randNum = UnityEngine.Random.Range(0, powerupElements.Count);
        return powerupElements[randNum];
    }

    public void RaisePowerupEvent(PowerupElement element)
    {
        if (element.PowerupEvent != null) element.PowerupEvent.Raise();
    }

    public void Start()
    {
        //var PowerupManager = FindObjectOfType<PowerupManager>();
        //if (PowerupManager != null)
            //PowerupManager.RegisterPowerupTarget(this);

        if (powerupStateType == null)
        {
            int rn = UnityEngine.Random.Range(1, 7);
            //Debug.Log("The random powerup value was " + rn.ToString());
            powerupStateType = ChooseRandomPowerup();// returns 1-6
        }
    }

    protected void OnCollisionEnter(Collision collision)
    {
        if (isColliding) return;
        isColliding = true;

        var projectile = collision.gameObject.GetComponent<Projectile>();
        if (projectile == null) return; //Only destroy on collision with projectile.
        Destroy(collision.gameObject);  //Destroy Projectile
        Destroy(this.gameObject);       //Destroy The target itself.
		RaisePowerupEvent(powerupStateType);
    }

	private void Update()
	{
        isColliding = false;
	}
}

//public enum PowerupState
//{
//    //TODO: consider converting to Scriptable Object type? Do more research.
//    None = 0,
//    SplitShot = 1,
//    SpeedBoost = 2,
//    GravityWell = 3,
//    InstantRemove = 4,
//    DoubleBurn = 5,
//    Homing = 6
//    //Pierce?
//}
