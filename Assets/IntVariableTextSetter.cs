using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntVariableTextSetter : MonoBehaviour
{

    public IntVariable intVariable;
    public Text text;

    public void UpdateText()
    {
        text.text = intVariable.Value.ToString();
    }

	public void Update()
	{
        UpdateText();
	}

}
