using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureSwitch : SwitchToggle
{
     
    int numberColliding = 0;

    private void OnTriggerEnter2D(Collider2D buttons)
    {
        numberColliding++;
        SwitchOn();
    }

    private void OnTriggerExit2D(Collider2D buttons)
    {
        numberColliding--;
        if(numberColliding == 0)
        {
            SwitchOff();
        }
    }
}
