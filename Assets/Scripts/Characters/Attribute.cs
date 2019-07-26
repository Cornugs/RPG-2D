using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Attribute")]
public class Attribute : ScriptableObject
{
    [Tooltip("Speed of movement")]
    public int speed;
    public int attack;
}
