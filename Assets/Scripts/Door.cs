using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    Collider2D playerCollider;
    Animator doorAnimator;

    [SerializeField] private bool isDoorOpen;

    [SerializeField] private int knocksToOpen;
    private int knocks;
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

    public void OpenDoor()
    {
        knocks++;
        if (!isDoorOpen && knocks >= knocksToOpen)
        {
            SetState(true);
            Debug.Log("Door Open!");

        }
    }

    public void CloseDoor()
    {
        knocks--;
        if (isDoorOpen && knocks < knocksToOpen)
        {
            SetState(false);
            Debug.Log("Door Closed!");


        }
    }


    public void ToggleDoor()
    {
        if (isDoorOpen)
        {
            CloseDoor();

        }
        else
        {
            OpenDoor();

        }

    }
    private void SetState(bool open)
    {
        isDoorOpen = open; //Så vi starter med at døra er Closed. Dermed er SetState = true.
        doorAnimator.SetBool("Open", open);

        playerCollider.isTrigger = open;
    }
}
