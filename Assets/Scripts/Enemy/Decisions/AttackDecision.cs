using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/Decisions/AttackState")]
public class AttackDecision : Decision {

    public override bool Decide(EnemyStateController controller)
    {
        // Check if an object is in front of this object, then attack it
        // RaycastHit2D hit = Physics2D.CircleCast(controller.eyes.position, 1.0f, controller.eyes.right, 10.0f);
        // RaycastHit2D hit = Physics2D.BoxCast(controller.eyes.position, new Vector2(controller.enemyData.attackRange, 1.0f), 0.0f, controller.eyes.TransformDirection(Vector3.right));
        RaycastHit2D hit = Physics2D.Raycast(controller.eyes.position, controller.eyes.TransformDirection(Vector3.right), controller.enemyData.attackRange, controller.playerLayer);

        Debug.DrawRay(controller.eyes.position, controller.eyes.TransformDirection(Vector3.right) * controller.enemyData.attackRange, Color.red);

        if (hit && hit.collider.CompareTag("Player"))
        {
            Debug.Log("I am close enough to attack the player");
            controller.chaseTarget = hit.transform;
            return true;
        }
        else
        {
            return false;
        }
    }

}
