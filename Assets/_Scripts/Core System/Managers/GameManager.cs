using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoboRyanTron.Unite2017.Events;
using RoboRyanTron.Unite2017.Variables;

public class GameManager : MonoBehaviour
{
    public GameEvent gameOverEvent;
    public GameEvent scoreChangeEvent;
    public IntVariable score;
    public FloatVariable powerupDuration;

    public bool InstantKill { get; private set; }
    public bool DoubleBurn { get; private set; }

    public int Hits
    {
        get { return hits; }
        set
        {
            hits = value;
            score.Value = value;
            scoreChangeEvent.Raise();
        }
    }

    private int hits = 0;


    private void Start()
    {
        //set time to normal time
        Time.timeScale = 1;
    }

    public void SetDoubleBurn()
    {
        StartCoroutine(DoubleBurnCoroutine());
    }

    public void SetInstantKill()
    {
        StartCoroutine(InstantKillCoroutine());
    }

    private IEnumerator DoubleBurnCoroutine()
    {
        DoubleBurn = true;
        yield return new WaitForSeconds(powerupDuration.Value);
        DoubleBurn = false;
    }

    private IEnumerator InstantKillCoroutine()
    {
        InstantKill = true;
        yield return new WaitForSeconds(powerupDuration.Value / 2);//Super powerups should be half the time.
        InstantKill = false;
    }

}
