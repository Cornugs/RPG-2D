using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Attribute attribute;
    public string myName;
    public int experience;

    protected void PresentPolitely()
    {
        Debug.Log("Hello, I'm " + myName);
    }
}
