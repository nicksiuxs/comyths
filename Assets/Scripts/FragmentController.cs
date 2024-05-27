using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            PlayerMovement playerScript = other.gameObject.GetComponent<PlayerMovement>();
            playerScript.GetFragment();
        }
    }
}
