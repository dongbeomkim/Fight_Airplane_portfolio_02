using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : StateMachineBehaviour
{
    Transform enemyTransform;
    Enemy enemy;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy = animator.GetComponent<Enemy>();
        enemyTransform = animator.GetComponent<Transform>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(enemy.player != null)
        {
            if(Vector3.Distance(enemyTransform.position, enemy.player.transform.position) < 60f)
            {
                animator.SetBool("isfollow", true);
            }
            if (Vector3.Distance(enemy.player.transform.position, enemyTransform.position) <= 15f)
            {
                animator.SetBool("isfollow", false);
                animator.SetBool("isattack", true);
                enemyTransform.LookAt(enemy.player.transform.position);
            }
        }


        if (enemy.HP <= 0f)
        {
            animator.SetBool("isdie", true);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
