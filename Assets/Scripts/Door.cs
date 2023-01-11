using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool isDoorOpen;
    Collider2D switchCollider;

    // Start is called before the first frame update
    void Start()
    {
        switchCollider= GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenDoor()
    {
        if (!isDoorOpen)
        {
            SetState(true);
        }
    }

    public void CloseDoor()
    {
        if (isDoorOpen)
        {
            SetState(false);
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

        switchCollider.isTrigger = open;
    }
}
