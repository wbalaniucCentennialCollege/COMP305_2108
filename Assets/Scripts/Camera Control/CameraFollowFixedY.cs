using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowFixedY : MonoBehaviour {

    public Transform playerPos;
    public float viewSize = 5;

    void Start()
    {
        this.GetComponent<Camera>().orthographicSize = viewSize;    
    }

    // Update is called once per frame
    void Update () {
        if (playerPos != null)
        {
            this.transform.position = new Vector3(playerPos.position.x, transform.position.y, transform.position.z);
        }
    }
}
