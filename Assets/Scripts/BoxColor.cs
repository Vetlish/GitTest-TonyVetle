using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxColor : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<Renderer>().material.color = new Color(0, 204, 102);
    }
}
