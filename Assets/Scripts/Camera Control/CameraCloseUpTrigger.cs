using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCloseUpTrigger : MonoBehaviour {

    public Camera mainCamera;
    public Camera closeUpCamera;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            mainCamera.enabled = false;
            closeUpCamera.enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            closeUpCamera.enabled = false;
            mainCamera.enabled = true;
        }
    }
}
