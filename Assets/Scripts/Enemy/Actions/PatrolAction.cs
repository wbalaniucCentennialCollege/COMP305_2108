using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Patrol")]
public class PatrolAction : Action
{
    public override void Act(EnemyStateController controller)
    {
        Patrol(controller);
    }

    private void Patrol(EnemyStateController controller)
    {
        // Begin enemy walking
        // controller.transform.position = Vector2.SmoothDamp(controller.transform.position, controller.waypoints[controller.nextWaypoint].position, ref vel, 0.3f, 50.0f, Time.deltaTime);
        // Vector2 walkVector = Vector2.Lerp(controller.transform.position, controller.waypoints[controller.nextWaypoint].position, Time.fixedDeltaTime * 0.5f);
        Vector2 walkVector = Vector2.MoveTowards(controller.transform.position, controller.waypoints[controller.nextWaypoint].position, Time.fixedDeltaTime * controller.enemyData.patrolSpeed);
        controller.transform.position = new Vector3(walkVector.x, controller.transform.position.y, controller.transform.position.z);

        // Determine distance remaining to the target
        // float distanceToWaypoint = Mathf.Abs(Vector2.Distance(controller.transform.position, controller.waypoints[controller.nextWaypoint].position));
        float distanceToWaypoint = Mathf.Abs(controller.transform.position.x - controller.waypoints[controller.nextWaypoint].position.x);

        //Debug.Log(distanceToWaypoint);

        if(distanceToWaypoint < 0.2)
        {
            controller.nextWaypoint = (controller.nextWaypoint + 1) % controller.waypoints.Count;
        }
        
    }
}
