using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandScript : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // to fix animation bug, manually untrigger the "jump" state upon landing, no matter the circumstance
        animator.ResetTrigger(AnimationStrings.jump);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // animator.ResetTrigger(AnimationStrings.jump);
    }
}
