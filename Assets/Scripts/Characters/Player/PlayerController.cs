using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private InputPlayer inputPlayer;
    private Transform transformed;
    private Rigidbody2D myRigidBody2D;
    private Animator myAnimator;
    private SpriteRenderer mySprite;
    public Attribute attributesPlayer;
    private Attacker attacker;

    private float axisX;
    private float axisY;
    int xHashCode;
    int yHashCode;
    int runningHashCode;
    int attackingHashCode;

    // Start is called before the first frame update
    void Start()
    {
        attacker = GetComponent<Attacker>();
        inputPlayer = GetComponent<InputPlayer>();
        transformed = GetComponent<Transform>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        mySprite = GetComponent<SpriteRenderer>();
        xHashCode = Animator.StringToHash("X");
        yHashCode = Animator.StringToHash("Y");
        runningHashCode = Animator.StringToHash("Running");
        attackingHashCode = Animator.StringToHash("Attacking");
    }

    // FixedUpdate is called once per frame in Physics
    void FixedUpdate()
    {
        // Movement
        if (myAnimator.GetBool(attackingHashCode))
        {
            myRigidBody2D.velocity = Vector2.zero;
        } else {
            Vector2 vectorVelocity = new Vector2(axisX, axisY) * attributesPlayer.speed;
            myRigidBody2D.velocity = vectorVelocity;
        }
    }

    // Update is called once per frame in GameLogic
    private void Update()
    {
        axisX = inputPlayer.horizontalAxis;
        axisY = inputPlayer.verticalAxis;

        //FlipSprite();

        if (axisX != 0 || axisY != 0)
        {
            SetXYAnimator();
            myAnimator.SetBool(runningHashCode, true);
        } else {
            myAnimator.SetBool(runningHashCode, false);
        }

        if(Input.GetButtonDown("Attack"))
        {
            myAnimator.SetBool(attackingHashCode, true);
        }
    }

    private void FlipSprite()
    {
        if (axisX < 0 && Mathf.Abs(axisY) < Mathf.Abs(axisX))
        {
            mySprite.flipX = true;
        }
        else if (axisX != 0)
        {
            mySprite.flipX = false;
        }
    }

    private void SetXYAnimator()
    {
        myAnimator.SetFloat(xHashCode, axisX);
        myAnimator.SetFloat(yHashCode, axisY);
    }

    private void AttackController()
    {
        attacker.Attack(inputPlayer.lookDirection, attributesPlayer.attack);
        myAnimator.SetBool(attackingHashCode, false);
    }

}
