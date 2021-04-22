using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObj : MonoBehaviour
{
    void Start()
    {
        int random = Random.Range(0, 2);
        transform.GetChild(random).gameObject.SetActive(true);
    }
}
