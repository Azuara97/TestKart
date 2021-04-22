using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerasManager : MonoBehaviour
{
    //Cameras
    private GameObject startCamera;
    private GameObject playerCamera;
    private GameObject selectionCamera;

    void Start()
    {
        setCameras();
    }

    //Set
    private void setCameras()
    {
        startCamera = transform.GetChild(0).gameObject;
        playerCamera = transform.GetChild(1).gameObject;
        selectionCamera = transform.GetChild(2).gameObject;
    }

    //Actives
    public void activePlayerCamera()
    {
        startCamera.SetActive(false);
        selectionCamera.SetActive(false);
        playerCamera.SetActive(true);
    }
    public void activeSelectionCamera()
    {
        startCamera.SetActive(false);
        playerCamera.SetActive(false);
        selectionCamera.SetActive(true);
    }
}
