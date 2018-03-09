using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowWithBuffer : MonoBehaviour {

    public Transform playerPos;
    public float cameraSafeOffsetSize = 5.0f;
   

    void Start()
    {
        BoxCollider2D bCol2D = this.gameObject.AddComponent<BoxCollider2D>();
        bCol2D.size = new Vector2(cameraSafeOffsetSize, 10.0f);
        bCol2D.isTrigger = true;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (playerPos != null)
        {
            if (playerPos.position.x < transform.position.x - (0.5f * cameraSafeOffsetSize))
            {
                this.transform.position = new Vector3(playerPos.position.x + (0.5f * cameraSafeOffsetSize), transform.position.y, transform.position.z);
            }
            else if (playerPos.position.x > transform.position.x + (0.5f * cameraSafeOffsetSize))
            {
                this.transform.position = new Vector3(playerPos.position.x - (0.5f * cameraSafeOffsetSize), transform.position.y, transform.position.z);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Vector3 thresholdL = new Vector3(
            this.transform.position.x - (0.5f * cameraSafeOffsetSize),
            this.transform.position.y,
            this.transform.position.z);

        Vector3 thresholdR = new Vector3(
            this.transform.position.x + (0.5f * cameraSafeOffsetSize),
            this.transform.position.y,
            this.transform.position.z);

        Gizmos.DrawLine(thresholdL, thresholdR);
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(thresholdL, new Vector3(thresholdL.x, thresholdL.y + 10, thresholdL.z));
        Gizmos.DrawLine(thresholdL, new Vector3(thresholdL.x, thresholdL.y - 10, thresholdL.z));

        Gizmos.DrawLine(thresholdR, new Vector3(thresholdR.x, thresholdR.y + 10, thresholdR.z));
        Gizmos.DrawLine(thresholdR, new Vector3(thresholdR.x, thresholdR.y - 10, thresholdR.z));
    }
}
