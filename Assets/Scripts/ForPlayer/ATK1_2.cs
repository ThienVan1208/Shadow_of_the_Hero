using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATK1_2 : StateMachineBehaviour
{
    public MainControl main;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        MainControl.isAttacking = true;
        
        //Audio.sound.swordATK2();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        if (MainControl.getATK1)
        {
            // Clear previous attack flags
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            MainControl.getATK2 = true;
            
            animator.SetTrigger("ATK2");
        }
        }
    }
}
