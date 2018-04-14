using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowLerp : MonoBehaviour {

    private Renderer rend;

    public float Speed = .2f;
    public List<Color> colors;

    private int colorIndex;
    private int ColorIndex
    {
        get
        {
            colorIndex++;
            if (colorIndex == colors.Count) colorIndex = 0;
            return colorIndex;
        }
    }

	// Use this for initialization
	void Start () {
        rend = GetComponentInChildren<Renderer>();
        StartCoroutine(ChangeColor());
	}
	
	// Update is called once per frame
	void OnDestroy () {
        StopAllCoroutines();
    }

    public IEnumerator ChangeColor()
    {
        while (true)
        {
            if (rend != null)
                rend.material.SetColor("_Color",colors[ColorIndex]);
            yield return new WaitForSeconds(Speed);
        }
    }
}
