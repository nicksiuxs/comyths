using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndergroundController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        FindObjectOfType<PlayerMovement>().SendMessage("ValidateLives");
    }

}
