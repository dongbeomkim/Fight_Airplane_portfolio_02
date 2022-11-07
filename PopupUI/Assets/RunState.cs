using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : StateMachineBehaviour
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
            if(Vector3.Distance(enemy.player.transform.position, enemyTransform.position) > 20f)
            {
                animator.SetBool("isfollow", false);
                enemy.nvAgent.SetDestination(enemy.Pos);
            }
            else if(Vector3.Distance(enemy.player.transform.position, enemyTransform.position) > 5f)
            {
                animator.SetBool("isfollow", true);
                enemy.nvAgent.SetDestination(enemy.player.transform.position);
            }
            else if(Vector3.Distance(enemy.player.transform.position, enemyTransform.position) <= 5f)
            {
                animator.SetBool("isfollow", false);
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
