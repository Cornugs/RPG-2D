using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Attribute attribute;
    public string myName;
    public int experience;

    protected void IntroduceYourselfPolitely()
    {
        Debug.Log("Hello, I'm " + myName);
    }
}
