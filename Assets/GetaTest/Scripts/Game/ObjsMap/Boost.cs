using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            if (player)
            {
                player.setSpeedBoost(1f);
            }
            else { Debug.Log("No encontro PlayerMovement"); }
            Destroy(gameObject);
        }
    }
}
