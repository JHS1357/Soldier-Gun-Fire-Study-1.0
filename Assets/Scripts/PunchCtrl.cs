using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchCtrl : MonoBehaviour
{
    private Animator animator;

    private bool isAttack = false;
    private int comboCount = 0;

    private float comboDelayTime = 0.0f;
    private readonly float comboDelay = 1.0f;
    private readonly int maxComboCount = 3;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Attack();
        }

        CheckComboDelay();
    }

    public void EndAttack()
    {
        isAttack = false;
    }

    private void CheckComboDelay()
    {
        if (isAttack) return;
        if (comboCount == 0) return;

        comboDelayTime += Time.deltaTime;

        if(comboDelayTime > comboDelay)
        {
            comboDelayTime = 0.0f;
            comboCount = 0;
        }
    }

    private void Attack()
    {
        if (isAttack) return;
                
        isAttack = true;
        animator.SetTrigger("Attack");
        animator.SetInteger("ComboCount", comboCount);

        comboCount = ++comboCount % maxComboCount;
        comboDelayTime = 0.0f;
    }
}
