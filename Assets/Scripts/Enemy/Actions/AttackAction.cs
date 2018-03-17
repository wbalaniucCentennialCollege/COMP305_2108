using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/Actions/Attack")]
public class AttackAction : Action {

    public override void Act(EnemyStateController controller)
    {
        Attack(controller);
    }

    public void Attack(EnemyStateController controller)
    {
        controller.enemyAttack.Attack();
    }
}
