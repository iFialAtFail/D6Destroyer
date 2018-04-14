using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitStateSetter : MonoBehaviour {

    public IntVariable splitState;
    public bool shouldResetOnDestroy = true;
    private int initialValue;

    private void Start()
    {
        initialValue = splitState.Value;
    }

    private void OnDestroy()
    {
        if (shouldResetOnDestroy)
            splitState.Value = initialValue;
    }
}
