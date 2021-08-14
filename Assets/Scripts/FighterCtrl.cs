using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterCtrl : PlayerCtrl
{
    public Transform leftHandPos;
    public float ikBlendWeight = 0.8f;

    private Animator animator;

    private readonly int hashSpeed = Animator.StringToHash("FighterSpeed");
    private readonly int hashDirX = Animator.StringToHash("FighterDirX");
    private readonly int hashDirY = Animator.StringToHash("FighterDirY");

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private new void Update()
    {
        base.Update();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            //animator.applyRootMotion = true;
            animator.SetTrigger("Jump");
        }
    }

    protected override void SetAnimation()
    {
        animator.SetFloat(hashSpeed, moveSpeed);

        animator.SetFloat(hashDirX, moveDir.x);
        animator.SetFloat(hashDirY, moveDir.z);
    }

    /*
    private void OnAnimatorIK(int layerIndex)
    {
        animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, ikBlendWeight);
        animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, ikBlendWeight);

        animator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandPos.position);
        animator.SetIKRotation(AvatarIKGoal.LeftHand, leftHandPos.rotation);
    }*/
}
