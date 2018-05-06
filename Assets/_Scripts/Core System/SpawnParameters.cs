using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace D6Destroyer.ScriptableObjects
{
    [CreateAssetMenu]
    public class SpawnParameters : ScriptableObject
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

}
