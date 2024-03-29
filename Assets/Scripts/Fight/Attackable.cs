﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackable : MonoBehaviour
{
    private Health myHealth;
    private Rigidbody2D myRigidbody;

    private void Start()
    {
        myHealth = GetComponent<Health>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    public void ReceiveAttack()
    {
        myHealth.CurrentHealth -= 1;
    }

    public void ReceiveAttack(Vector2 attackDirection, int hurt)
    {
        myHealth.ModifyCurrentHealth(-hurt);
        myRigidbody.AddForce(attackDirection * hurt * 100);
    }
}
