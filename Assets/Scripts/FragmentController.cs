using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entre");
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<PlayerMovement>().SendMessage("GetFragment");
        }
    }
}
