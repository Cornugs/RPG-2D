using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Enemy
{
    private InputEnemy input;
    private Attacker attacker;
    private Animator myAnimator;
    private SpriteRenderer mySpriteRenderer;
    private Vector2 attackDirection;
    private bool dead = false;
    private bool attacking = false;
    private bool inFight = false;
    int runningHashCode;
    int deadHashCode;
    int attackHashCode;
    int blockHashCode;
    [SerializeField] private float detectionDistance = 1f;
    [SerializeField] private float attackDistance = 1f;

    private void Start()
    {
        input = GetComponent<InputEnemy>();
        attacker = GetComponent<Attacker>();
        myAnimator = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        runningHashCode = Animator.StringToHash("Running");
        deadHashCode = Animator.StringToHash("Dead");
        attackHashCode = Animator.StringToHash("Attack");
        blockHashCode = Animator.StringToHash("Block");
        PresentPolitely();
    }

    private void Update()
    {
        Behavior();
    }

    public void Behavior()
    {
        if(!dead)
        {
            if (!attacking && input.DistancePlayer < attackDistance)
            {
                PerformAttack();
            }
            else if (!attacking && (inFight || input.DistancePlayer < detectionDistance)) {
                MoveToPlayer();
            }
        }
    }

    private void PerformAttack()
    {
        int attackProbability = Random.Range(0, 100);
        Debug.Log(attackProbability);
        myAnimator.SetBool(runningHashCode, false);
        if (attackProbability > 97)
        {
            attackDirection = input.DirectionToPlayer;
            attacking = true;
            inFight = true;            
            myAnimator.SetTrigger(attackHashCode);
        }
    }

    private void MoveToPlayer()
    {
        myAnimator.SetBool(runningHashCode, true);
        FlipSprite();
        transform.position += (Vector3)input.DirectionToPlayer * attribute.speed * Time.deltaTime;
    }

    private void FlipSprite()
    {
        if (input.Horizontal < 0)
        {
            mySpriteRenderer.flipX = true;
        } else {
            mySpriteRenderer.flipX = false;
        }
    }

    public void KnightAttack()
    {
        attacker.Attack(attackDirection, attribute.attack);
    }

    public void SetAttackingFalse()
    {
        attacking = false;
    }

    public void Die()
    {
        dead = true;
        myAnimator.SetBool(deadHashCode, true);
    }
}
