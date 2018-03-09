using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFloor : MonoBehaviour {

    private float startY;
    private float endY = 4.0f;

    private float speed = 2.0f;

	// Use this for initialization
	void Start () {
        startY = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = Vector2.up * Mathf.PingPong(Time.time * speed, Mathf.Abs(startY - 4.0f));
        
	}
}
