using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputEnemy : MonoBehaviour
{
    private Transform player;
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
    public float Distance
    {
        get
        {
            return DirectionToPlayer.magnitude;
        }
    } 

    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.instance.player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        DirectionToPlayer = player.position - transform.transform.position;
    }
}
