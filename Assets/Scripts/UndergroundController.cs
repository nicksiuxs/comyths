using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndergroundController : MonoBehaviour
{
    /// <summary>
    /// Method to detect de colission with the player
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<PlayerMovement>().SendMessage("ValidateLives");
        }
    }

}
