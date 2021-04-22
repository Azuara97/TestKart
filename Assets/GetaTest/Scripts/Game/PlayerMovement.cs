using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //MovementVariables
    [SerializeField]
    private float speed = 0f;
    [SerializeField]
    private bool boost = false;

    //OtherVariables
    private MyGameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<MyGameManager>();
    }

    void Update()
    {
        if (gameManager.getInGameBool())
        {
            float translation = Input.GetAxis("Vertical") + speed;
            float rotation = Input.GetAxis("Horizontal");

            transform.Translate(Vector3.forward * translation);
            transform.Rotate(Vector3.up * rotation);

            if (Input.GetKey(KeyCode.Space))
            {
                speed = -.6f;
            }
            else if(!boost)
            {
                speed = 0f;
            }
        }
    }

    //Obj
    public void setSpeedOil(float _speed)
    {
        speed = _speed;
        StartCoroutine(resetSpeedOil());
    }
    public void setSpeedBoost(float _speed)
    {
        speed = _speed;
        boost = true;
        StartCoroutine(resetSpeedBoost());
    }

    //Coroutines
    IEnumerator resetSpeedOil()
    {
        yield return new WaitForSeconds(1f);
        speed = 0f;
    }
    IEnumerator resetSpeedBoost()
    {
        yield return new WaitForSeconds(1f);
        speed = 0f;
        boost = false;
    }
}
