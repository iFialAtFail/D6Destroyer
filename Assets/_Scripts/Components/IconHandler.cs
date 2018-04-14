using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RoboRyanTron.Unite2017.Variables;

public class IconHandler : MonoBehaviour {

    public Image icon;
    public float fadePercentage = .75f;
    public FloatVariable timeInSecondsForFading;
    public bool debug = false;

	// Use this for initialization
	void Start () {
        Fade(fadePercentage);
	}
	
    public void Fade(float percentage){
        var tempColor = icon.color;
        tempColor.a = percentage;
        icon.color = tempColor;
    }

    public void Unfade(){
        var tempColor = icon.color;
        tempColor.a = 1f;
        icon.color = tempColor;
    }

	private void Update()
	{
        if (debug){
            Fade(fadePercentage);
        }
	}

    public void UnfadeForSeconds(){
        StartCoroutine(UnfadeForSecondsRoutine());
    }

    private IEnumerator UnfadeForSecondsRoutine(){
        Unfade();
        yield return new WaitForSeconds(timeInSecondsForFading.Value);
        Fade(fadePercentage);
    }
}
