using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoboRyanTron.Unite2017.Events;

[CreateAssetMenu]
public class PowerupElement : ScriptableObject
{
    public string Name;
    public string Description;
    public GameEvent PowerupEvent;
}
