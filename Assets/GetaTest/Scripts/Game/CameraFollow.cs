using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //Variables
    private Transform player;
    private Vector3 offset = new Vector3(0f, 3f, -7f);

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject.transform;
    }

    private void LateUpdate()
    {
        transform.position = player.TransformPoint(offset);
        transform.LookAt(player);
    }
}
