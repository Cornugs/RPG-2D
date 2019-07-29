using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Enemy
{
    private InputEnemy input;

    private void Start()
    {
        input = GetComponent<InputEnemy>();
        PresentPolitely();
    }

    private void Update()
    {
        transform.position += (Vector3)input.DirectionToPlayer * attribute.speed * Time.deltaTime;
    }
}
