using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToggle : MonoBehaviour
{
    Animator switchAnimator;

    public GameObject switchTarget;
    public bool switchOn;//For switch knappen

    public string OnMessage;
    public string OffMessage;
    // Start is called before the first frame update
    void Start()
    {
        switchAnimator= GetComponent<Animator>();
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
            Debug.Log("Switch Off");
        }
        else
        {
            SwitchOn();
            Debug.Log("Switch On");
        }
    }

    private void SetState(bool on)
    {
        switchOn = on; //Så vi starter med at switch er Off. Dermed er SetState = true.

        switchAnimator.SetBool("On", on);

        if (on)
        {
            if (switchTarget != null && !string.IsNullOrEmpty(OnMessage))
            {
                switchTarget.SendMessage(OnMessage);
            }


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
