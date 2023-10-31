using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootAttackAnimationStateChanger : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] string currentState = "FootAttackIdle";

    void Start(){
        ChangeAnimationState(currentState);
    }

    public void ChangeAnimationState(string newAnimationState, float speed = 1){
        if(newAnimationState == currentState){
            return;
        }
        currentState = newAnimationState;
        animator.Play(newAnimationState);
    }
}
