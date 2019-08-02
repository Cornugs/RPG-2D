using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputEnemy : MonoBehaviour
{
    public Transform player;
    public Vector2 DirectionToPlayer { get; private set; }
    public float Horizontal
    {
        get
        {
            return DirectionToPlayer.x;
        }
    }
    public float Vertical
    {
        get
        {
            return DirectionToPlayer.y;
        }
    }
    public float DistancePlayer
    {
        get
        {
            return DirectionToPlayer.magnitude;
        }
    } 

    // Start is called before the first frame update
    void Start()
    {
        DefineDirectionToPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        DefineDirectionToPlayer();
    }

    private void DefineDirectionToPlayer()
    {
        DirectionToPlayer = player.position - transform.position;
    }
}
