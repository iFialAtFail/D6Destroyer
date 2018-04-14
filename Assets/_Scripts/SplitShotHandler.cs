using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitShotHandler : MonoBehaviour
{

    public IntVariable splitState;
    public int MAX_SPLIT_STATE = 10;

    public void IncreaseSplitState()
    {
        if (splitState.Value < MAX_SPLIT_STATE)
        {
            splitState.Value++;
        }
    }

    public void DecreaseSplitState(){
        if (splitState.Value >1)
        {
            splitState.Value--;
        }
    }

}
