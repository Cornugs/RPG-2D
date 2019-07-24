using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactive : MonoBehaviour
{
    private Collider2D myCollider;
    public UnityEvent onInteraction;

    // Start is called before the first frame update
    private void Start()
    {
        myCollider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        onInteraction?.Invoke();
    }
}
