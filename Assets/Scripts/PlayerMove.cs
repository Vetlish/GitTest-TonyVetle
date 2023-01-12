using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;

    List<Collider2D> switchColliders = new List<Collider2D>();

    Vector2 movement;

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //animator.SetFloat("Horizontal", movement.x);
        //animator.SetFloat("Vertical", movement.y);
        //animator.SetFloat("speed", movement.sqrMagnitude);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            switchColliders.ForEach(n => n.SendMessage("Use", SendMessageOptions.DontRequireReceiver));
        }
    }


    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D switches)
    {
        switchColliders.Add(switches);
    }
    private void OnTriggerExit2D(Collider2D switches)
    {
        switchColliders.Remove(switches);
    }
}
