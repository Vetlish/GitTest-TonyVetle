using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    Collider2D playerCollider;
    Rigidbody2D rb2d;

    //[SerializeField] Transform movingPlatform;
    [SerializeField] bool isMoving;
    [SerializeField] float platformSpeed;

    void Start()
    {
        playerCollider= GetComponent<Collider2D>();
        rb2d= GetComponent<Rigidbody2D>();
    }


    private void MoveUp()
    {
        if (!isMoving)
        {
            rb2d.velocity = new Vector2(0f, platformSpeed);
            SetState(true);
            Debug.Log("Moving UP");
        }
    }

    private void MoveDown()
    {
        if (!isMoving)
        {
            rb2d.velocity = new Vector2(0f, -platformSpeed);
            SetState(true);
            Debug.Log("Moving DOWN");
        }
    }

    private void Stop()
    {
        if(isMoving)
        {
            rb2d.velocity = Vector2.zero;
            SetState(false);
            Debug.Log("Stop");
        }
    }

    private void SetState(bool moving)
    {
        isMoving = moving; //S� vi starter med at d�ra er Closed. Dermed er SetState = true.
        //doorAnimator.SetBool("Open", moving);

        playerCollider.isTrigger = moving;
    }
}
