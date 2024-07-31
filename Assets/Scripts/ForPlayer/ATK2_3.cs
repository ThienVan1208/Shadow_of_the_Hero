using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATK2_3 : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        MainControl.isAttacking = true;
        //Audio.sound.swordATK2();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (MainControl.getATK2)
        {
            // Clear previous attack flag
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
                MainControl.getATK3 = true;
                
                animator.SetTrigger("ATK3");
        }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    MainControl.instance.getATK1 = false;
    //    MainControl.instance.getATK2 = false;
    //    MainControl.instance.getATK3 = false;
    //}
}
