using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName ="PluggableAI/Actions/Chase")]
public class ChaseAction : Action
{
    public override void Init(EnemyStateController controller)
    {
    }
    public override void Act(EnemyStateController controller)
    {
        Chase(controller);
    }

    public void Chase(EnemyStateController controller)
    {
        // Chase the player
        Vector2 walkVector = Vector2.MoveTowards(controller.transform.position, controller.chaseTarget.position, Time.fixedDeltaTime * controller.stats.chaseSpeed);
        controller.transform.position = new Vector3(walkVector.x, controller.transform.position.y, controller.transform.position.z);
    }
}
