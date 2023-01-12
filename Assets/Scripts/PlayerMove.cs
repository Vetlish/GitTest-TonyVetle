using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform interactor;
    [SerializeField] private Animator animator;

    List<Collider2D> switchColliders = new List<Collider2D>();

    Vector2 movement;


    private void Update()
    {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);

        if(Input.GetAxisRaw("Horizontal")==1 || Input.GetAxisRaw("Horizontal")==-1 || Input.GetAxisRaw("Vertical")==1 || Input.GetAxisRaw("Vertical") == -1)
        {
            animator.SetFloat("LastHorizontal", Input.GetAxisRaw("Horizontal"));
            animator.SetFloat("LastVertical", Input.GetAxisRaw("Vertical"));
        }
        if(Input.GetAxisRaw("Horizontal") > 0)
        {
            interactor.localRotation = Quaternion.Euler(0, 0, 90);
        }        
        if(Input.GetAxisRaw("Horizontal") < 0)
        {
            interactor.localRotation = Quaternion.Euler(0, 0, -90);
        } 
        if(Input.GetAxisRaw("Vertical") > 0)
        {
            interactor.localRotation = Quaternion.Euler(0, 0, 180);
        } 
        if(Input.GetAxisRaw("Vertical") < 0)
        {
            interactor.localRotation = Quaternion.Euler(0, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            animator.SetBool("Attacking", true);
            animator.SetBool("Attacking", false);
        }

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
