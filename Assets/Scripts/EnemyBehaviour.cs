using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public GameObject player;

    private void Update()
    {
        if (player == null)
        {
            return;
        }
        else
        {
            Vector3 direction = player.transform.position - transform.position;

            if (direction.x >= 0.0f)
            {
                transform.localScale = Vector3.one;
            }
            else
            {
                transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            }

            float distance = Mathf.Abs(player.transform.position.x - transform.position.x);

            if (distance < 5.0f)
            {
                DetectPlayer();
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerMovement playeScript = player.GetComponent<PlayerMovement>();
            playeScript.HaveDamage();
            Destroy(gameObject);
        }
    }

    private void DetectPlayer()
    {
        // Debug.Log("Detectando jugaddor");
    }
}
