using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToggle : MonoBehaviour
{
    public GameObject switchTarget;
    public bool switchOn;//For switch knappen

    public string OnMessage;
    public string OffMessage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchOn()
    {
        if (!switchOn)
        {
            SetState(true);
        }
    }

    public void SwitchOff()
    {
        if (switchOn)
        {
            SetState(false);
        }
    }

    public void ToggleSwitch()
    {
        if (switchOn)
        {
            SwitchOff();
        }
        else
        {
            SwitchOn();
        }
    }

    private void SetState(bool on)
    {
        switchOn = on; //Så vi starter med at døra er Closed. Dermed er SetState = true.

        if (on)
        {
            if (switchTarget != null && !string.IsNullOrEmpty(OnMessage))
            {
                switchTarget.SendMessage(OnMessage);
            }

            else
            {
                if (switchTarget != null && !string.IsNullOrEmpty(OffMessage))
                {
                    switchTarget.SendMessage(OffMessage);
                }
            }
        }
    }

}
