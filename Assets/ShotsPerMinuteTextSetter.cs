using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RoboRyanTron.Unite2017.Variables;

public class ShotsPerMinuteTextSetter : MonoBehaviour {
    public Text text;
    public FloatVariable floatVariable;

    public void UpdateText(){
        text.text = (60 / floatVariable.Value).ToString() + " S.P.M.";
    }

	public void Start()
	{
        UpdateText();
	}
}
