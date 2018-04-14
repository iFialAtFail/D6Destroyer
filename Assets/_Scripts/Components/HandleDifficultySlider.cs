using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandleDifficultySlider : MonoBehaviour {

    public Text difficultyText;
    public Slider difficultySlider;
    public IntVariable difficultyVariable;

	// Use this for initialization
	void Start () {
        difficultyText.text = GetDifficultyString(difficultyVariable.Value);
        difficultySlider.value = difficultyVariable.Value;
        difficultySlider.onValueChanged.AddListener(ChangeDifficulty);
	}
	
    public void ChangeDifficulty(float difficulty){
        difficultyText.text = GetDifficultyString((int)difficulty);
        difficultyVariable.Value = (int)difficulty;
    }

	
    public string GetDifficultyString(int difficulty){
        switch (difficulty)
        {
            case 1:
                return "Easy";
            case 2:
                return "Normal";
            case 3:
                return "Hard";
            case 4:
                return "Impossible";
            default:
                return "Unconfigured";
        }
    }
}
