using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlayer : MonoBehaviour
{
    public float verticalAxis { get; private set; }
    public float horizontalAxis { get; private set; }
    public bool attack { get; private set; }
    public bool skill1 { get; private set; }
    public bool skill2 { get; private set; }
    public bool inventory { get; private set; }
    public bool interact { get; private set; }

    [HideInInspector] public Vector2 lookDirection = new Vector2(0, -1f);

    // Update is called once per frame
    void Update()
    {
        //attack = Input.GetKeyDown(KeyCode.A);
        attack = Input.GetButtonDown("Attack");
        skill1 = Input.GetButtonDown("Skill1");
        skill2 = Input.GetButtonDown("Skill2");
        inventory = Input.GetButtonDown("Inventory");
        interact = Input.GetButtonDown("Interact");

        //Defining movement axes
        horizontalAxis = Input.GetAxis("Horizontal");
        verticalAxis = Input.GetAxis("Vertical");

        DetermineLookDirection();

        //Debug.DrawLine(transform.position, transform.position + (Vector3)lookDirection.normalized * 3, Color.green);
    }

    private void DetermineLookDirection()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            lookDirection.x = horizontalAxis;
            lookDirection.y = verticalAxis;
        }
    }
}
