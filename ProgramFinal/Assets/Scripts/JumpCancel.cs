using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class JumpCancel : StateMachineBehaviour
{
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetBool("isGrounded") && animator.GetFloat("yVelocity") < 0)
        {
            animator.StopPlayback();
            animator.Play("Idle");
        }
    }
}
