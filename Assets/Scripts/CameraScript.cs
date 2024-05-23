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
        transform.position = position;
    }
}
