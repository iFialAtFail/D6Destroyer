using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoboRyanTron.Unite2017.Events;

public class AntiPowerup : MonoBehaviour {

    public List<AntiPowerupElement> antiPowerupElements;
    public AntiPowerupElement antiPowerupElement;
    private bool colliding = false;

	private void Start()
	{
        if (antiPowerupElement == null){
            antiPowerupElement = ChooseRandomAntiPowerup();
        }
	}

	private void Update()
	{
        colliding = false;
	}

	private void OnCollisionEnter(Collision collision)
	{
        if (colliding) return; //Mix this with colliding = false on update ensures only one collision.
        colliding = true;
        var projectile = collision.gameObject.GetComponent<Projectile>();
        if (projectile == null) return;
        Destroy(collision.gameObject);
        Destroy(this.gameObject);
        RaiseAntiPowerupEvent(antiPowerupElement);
	}

    public AntiPowerupElement ChooseRandomAntiPowerup(){
        int randNum = UnityEngine.Random.Range(0, antiPowerupElements.Count);
        return antiPowerupElements[randNum];
    }

    public void RaiseAntiPowerupEvent(AntiPowerupElement element){
        if (element.antiPowerupEvent != null) element.antiPowerupEvent.Raise();
    }
}
