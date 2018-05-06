using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoboRyanTron.Unite2017.Events;

public class LifeManager : MonoBehaviour
{

    public GameEvent lostAllLives;
    public GameEvent updateLivesGUIEvent;//Maybe update lives gui game event?
    public IntVariable lives;
#if UNITY_EDITOR
    public bool invincibility = false;
#endif

    /// <summary>
    /// Lose a life. If lives is reduced to 0 or less, raise the game event.
    /// </summary>
    public void LoseALife()
    {
#if UNITY_EDITOR
        if (invincibility) return;
#endif
        lives.Value--;
        if (updateLivesGUIEvent != null)
        {
            updateLivesGUIEvent.Raise();
        }
        if (lives.Value <= 0)
        {
            lives.SetValue(0);
            if (lostAllLives != null)
            {
                lostAllLives.Raise();
            }
        }
    }

    /// <summary>
    /// Adds a live to the lives intvariable.
    /// </summary>
    public void AddALife()
    {
        lives.Value++;
    }

    /// <summary>
    /// Adds n number of lives.
    /// </summary>
    /// <param name="lives">Lives.</param>
    public void AddLives(int lives)
    {
        this.lives.Value += lives;
    }
}
