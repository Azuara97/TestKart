using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oil : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            if (player)
            {
                player.setSpeedOil(-0.8f);
            }
            else { Debug.Log("No encontro PlayerMovement"); }
        }
    }
}
