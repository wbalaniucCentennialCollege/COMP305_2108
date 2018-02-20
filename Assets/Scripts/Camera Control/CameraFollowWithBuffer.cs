using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowWithBuffer : MonoBehaviour {

    public Transform playerPos;
    public Transform playerMoveThreshold;

    void Start()
    {
        playerMoveThreshold = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(playerPos.position.x > playerMoveThreshold.position.x)
        {
            this.transform.position = new Vector3(playerPos.position.x, transform.position.y, transform.position.z);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(playerMoveThreshold.position, new Vector2(this.transform.position.x, this.transform.position.y + 100));
        Gizmos.DrawLine(playerMoveThreshold.position, new Vector2(this.transform.position.x, this.transform.position.y - 100));
    }
}
