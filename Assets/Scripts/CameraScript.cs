using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        position.x = player.transform.position.x;
        float diferenceY = player.transform.position.y - transform.position.y;

        if (diferenceY > 3f || diferenceY < 0f)
        {
            position.y = player.transform.position.y;
        }

        transform.position = position;
    }
}
