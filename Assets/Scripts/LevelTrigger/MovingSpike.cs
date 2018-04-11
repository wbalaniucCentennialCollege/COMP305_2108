using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSpike : MonoBehaviour {
    public float platformMoveSpeed = 5.0f;
    public List<Transform> waypoints;

    private Vector3 target;
    private int waypointIndex;

	// Use this for initialization
	void Start () {
        if (waypoints != null)
            target = waypoints[waypointIndex].position;
        else
            Debug.Log("List of waypoints does not exist");
	}

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, platformMoveSpeed * Time.deltaTime);

        float distToTarget = (target - transform.position).magnitude; // Length of vector   

        if(distToTarget < 0.25f)
        {
            waypointIndex = (waypointIndex + 1) % waypoints.Count;

            target = waypoints[waypointIndex].position;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        for(int i = 1; i < waypoints.Count; i++)
        {
            Gizmos.DrawLine(waypoints[i - 1].position, waypoints[i].position);
        }
    }
}
