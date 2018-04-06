﻿using System.Collections;
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
    void Update()
    {
        if (playerPosition.position.x > transform.position.x - (0.5f * cfwb.cameraSafeOffsetSizeX))
        {
            cfwb.enabled = true;
            this.enabled = false;
        }

        if(transform.position.x < 0.0f)
        {
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
        }
    }
}
