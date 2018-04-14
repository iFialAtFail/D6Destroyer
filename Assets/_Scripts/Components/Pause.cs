using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

    /// <summary>
    /// Pauses the game by setting time scale to 0.
    /// </summary>
    public void Enable()
    {
        Time.timeScale = 0;
    }

    /// <summary>
    /// Unpauses the game by setting the time scale to 1.
    /// </summary>
	public void Disable()
	{
        Time.timeScale = 1;
	}
}
