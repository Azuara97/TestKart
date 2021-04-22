using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            MyGameManager gameManager = FindObjectOfType<MyGameManager>();
            if (gameManager)
            {
                gameManager.addExtraTime(7f);
            }
            else { Debug.Log("No encontro GameManager"); }
            Destroy(this);
        }
    }
}
