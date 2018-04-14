using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// This class manages an array of spawners. Spawners should be child objects of the object with this script on it.
/// If the spawners are not set in the inspector, this class will go out and find the spawners in the children.
/// </summary>
public class SpawnManager : MonoBehaviour
{
    public Spawner[] spawners;
    public IntVariable difficulty;

    public Powerup powerup;
    public AntiPowerup antiPowerup;

    private float startTime;
    private float powerupTime;
    private float antiPowerupTime;
    private float difficultyTimer;

    private SpawnParameters easySpawnRange = new SpawnParameters {
        timeRangeBtmLmt = 2,
        timeRangeTopLmt = 4,
        difficultyPctModifier = .99f,
        difficultyTimeStep = 2,
        spawnPctBtmRange = .1f,
        spawnPctTopRange = .3f, 
        powerupBtmTimeRng = 30,
        powerupTopTimeRng = 60 ,
        antiPowerupBtmTimeRng = 20,
        antiPowerupTopTimeRng = 60};
    private SpawnParameters normalSpawnRange = new SpawnParameters { 
        timeRangeBtmLmt = 2, 
        timeRangeTopLmt = 4,
        difficultyPctModifier = .99f, 
        difficultyTimeStep = 2, 
        spawnPctBtmRange = .2f,
        spawnPctTopRange = .4f, 
        powerupBtmTimeRng = 30, 
        powerupTopTimeRng = 60 ,
        antiPowerupBtmTimeRng = 20,
        antiPowerupTopTimeRng = 60};
    private SpawnParameters hardSpawnRange = new SpawnParameters { 
        timeRangeBtmLmt = 1f, 
        timeRangeTopLmt = 2, 
        difficultyPctModifier = .99f, 
        difficultyTimeStep = 2f,
        spawnPctBtmRange = .5f, 
        spawnPctTopRange = .9f, 
        powerupBtmTimeRng = 30, 
        powerupTopTimeRng = 60 ,
        antiPowerupBtmTimeRng = 20,
        antiPowerupTopTimeRng = 60};
    private SpawnParameters hardCoreSpawnRange = new SpawnParameters { 
        timeRangeBtmLmt = .5f, 
        timeRangeTopLmt = 4f, 
        difficultyPctModifier = .99f, 
        difficultyTimeStep = 1f, 
        spawnPctBtmRange = .5f, 
        spawnPctTopRange = 1f,
        powerupBtmTimeRng = 30,
        powerupTopTimeRng = 60, 
        antiPowerupBtmTimeRng = 20, 
        antiPowerupTopTimeRng = 60 };

    private class SpawnParameters
    {
        public float timeRangeBtmLmt;
        public float timeRangeTopLmt;
        public float spawnPctBtmRange;
        public float spawnPctTopRange;
        public float difficultyPctModifier;
        public float difficultyTimeStep;
        public float powerupBtmTimeRng;
        public float powerupTopTimeRng;
        public float antiPowerupBtmTimeRng;
        public float antiPowerupTopTimeRng;
    }

    //[Range(1, 4)]
    //public int difficulty = 1;

    public bool shouldSpawnTargets = true;

    public float spawnVariation = 2;

    // Use this for initialization
    void Start()
    {
        if (spawners == null || spawners.Length < 1)
        {
            spawners = GetComponentsInChildren<Spawner>();
        }
        startTime = Time.time;
        difficultyTimer = Time.time;
        powerupTime = Time.time;
        antiPowerupTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldSpawnTargets)
        {
            SpawnTargets();
        }
    }

    /// <summary>
    /// Spawn targets based on the difficulty level if enough time has elapsed.
    /// </summary>
    protected void SpawnTargets()
    {
        switch (difficulty.Value)
        {
            case 1:
                SpawnTargets(easySpawnRange);
                break;
            case 2:
                SpawnTargets(normalSpawnRange);
                break;
            case 3:
                SpawnTargets(hardSpawnRange);
                break;
            case 4:
                SpawnTargets(hardCoreSpawnRange);
                break;
            default:
                break;
        }

    }

    /// <summary>
    /// Spawns targets if enough time has elapsed and spawns only a certain percentage
    /// of the spawners.
    /// </summary>
    /// <param name="timeRange">The range in seconds to have the spawner fire.</param>
    /// <param name="pctRange">The percentage range you want indices chosen. .1f would be 10% of the spawners.</param>
    private void SpawnTargets(SpawnParameters parameters)
    {
        //Increase difficulty independent of spawn rate of targets.
        float stepTime = (Time.time - difficultyTimer);
        if (stepTime > parameters.difficultyTimeStep)
        {
            parameters.timeRangeBtmLmt *= parameters.difficultyPctModifier;
            parameters.timeRangeTopLmt *= parameters.difficultyPctModifier;
            difficultyTimer = Time.time;
        }

        float powTime = (Time.time - powerupTime);
        if (powTime > UnityEngine.Random.Range(parameters.powerupBtmTimeRng, parameters.powerupTopTimeRng))
        {
            powerupTime = Time.time;
            int spawner = UnityEngine.Random.Range(0, spawners.Length);
            spawners[spawner].Spawn(powerup.gameObject);
            return;//short circuit for now to handle only spawning the target.
        }

        float antipowTime = (Time.time - antiPowerupTime);
        if (antipowTime > UnityEngine.Random.Range(parameters.antiPowerupBtmTimeRng, parameters.antiPowerupTopTimeRng))
        {
            antiPowerupTime = Time.time;
            int spawner = UnityEngine.Random.Range(0, spawners.Length);
            spawners[spawner].Spawn(antiPowerup.gameObject);
            return;//short circuit for now to handle only spawning the target.
        }


        //Spawn targets within the range specified for the given difficulty.
        float time = (Time.time - startTime);
        if (time > UnityEngine.Random.Range(parameters.timeRangeBtmLmt, parameters.timeRangeTopLmt))
        {

            startTime = Time.time;

            int numberOfSpawnersToFire = Mathf.RoundToInt(spawners.Length * UnityEngine.Random.Range(parameters.spawnPctBtmRange, parameters.spawnPctTopRange));// Take total amount of spawners and multiply them by a percentage.
            int[] selectedIndices = new int[numberOfSpawnersToFire];

            initializeArray(ref selectedIndices);

            for (int i = 0; i < numberOfSpawnersToFire; i++)
            {
                int indice = UnityEngine.Random.Range(0, spawners.Length);
                while (selectedIndices.Contains(indice))
                {
                    indice = UnityEngine.Random.Range(0, spawners.Length);
                }
                selectedIndices[i] = indice;
            }

            for (int i = 0; i < selectedIndices.Length; i++)
            {
                spawners[selectedIndices[i]].Spawn(true, spawnVariation);
            }
        }
    }

    private void initializeArray(ref int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = -1;
        }
    }
}
