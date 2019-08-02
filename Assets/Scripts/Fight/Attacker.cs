using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    public Vector2 hitBox = new Vector2(1, 1);
    private Vector2 vectorAttack;
    private Vector2 pointA, pointB;
    public LayerMask layerAttack;
    private ContactFilter2D attackFilter;

    public float gap = 1f;

    private Collider2D[] attackColliders = new Collider2D[12];

    private void Start()
    {
        attackFilter.layerMask = layerAttack;
        attackFilter.useLayerMask = true;
    }

    private void Update()
    {
        Debug.DrawLine(transform.position, (Vector2)transform.position + vectorAttack, Color.yellow);
        Debug.DrawLine(pointA, pointB, Color.red);
    }

    public void Attack(Vector2 attackDirection, int hurt)
    {
        GameObject attackedObject;

        CreateHitBox(attackDirection);
        int elementsAttacked = Physics2D.OverlapArea(pointA, pointB, attackFilter, attackColliders);
        Debug.Log("The number of elements attacked is " + elementsAttacked);

        for(int i = 0; i < elementsAttacked; i++)
        {
            attackedObject = attackColliders[i].gameObject;

            if (attackedObject.GetComponent<Attackable>())
            {
                attackedObject.GetComponent<Attackable>().ReceiveAttack(attackDirection, hurt);
            }
        }
    }

    private void CreateHitBox(Vector2 attackDirection)
    {
        Vector2 scale = transform.lossyScale;
        Vector2 hitBoxScale = Vector2.Scale(hitBox, scale);

        vectorAttack = Vector2.Scale(attackDirection.normalized * gap, scale);
        pointA = (Vector2)transform.position + vectorAttack - hitBoxScale * 0.5f;
        pointB = pointA + hitBoxScale;
    }
}
