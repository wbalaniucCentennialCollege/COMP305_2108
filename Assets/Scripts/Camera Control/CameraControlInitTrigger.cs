using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlInitTrigger : MonoBehaviour {

    public Transform playerPosition;

    private CameraFollowWithBuffer cfwb;

	// Use this for initialization
	void Start () {
        cfwb = GetComponent<CameraFollowWithBuffer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (playerPosition.position.x > transform.position.x - (0.5f * cfwb.cameraSafeOffsetSize))
        {
            cfwb.enabled = true;
            this.enabled = false;
        }
	}
}
