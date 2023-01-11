using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isDoorOpen;
    Collider2D playerCollider;
    Animator doorAnimator;

    // Start is called before the first frame update
    void Start()
    {
        doorAnimator = GetComponent<Animator>();
        playerCollider= GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenedDoor()
    {
        if (!isDoorOpen)
        {
            SetState(true);
            Debug.Log("Door Open!");

        }
    }

    public void ClosingDoor()
    {
        if (isDoorOpen)
        {
            SetState(false);
            Debug.Log("Door Closed!");

        }
    }


    public void ToggleDoor()
    {
        if (isDoorOpen)
        {
            ClosingDoor();
        }
        else
        {
            OpenedDoor();
        }

    }
    private void SetState(bool open)
    {
        isDoorOpen = open; //Så vi starter med at døra er Closed. Dermed er SetState = true.
        doorAnimator.SetBool("Open", open);

        playerCollider.isTrigger = open;
    }
}
