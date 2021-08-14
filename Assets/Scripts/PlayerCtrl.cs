using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float rotSpeed = 5.0f;

    private float h = 0.0f;
    private float v = 0.0f;
    private float r = 0.0f;

    private Animation animation;
    private void Awake()
    {
        animation = GetComponent<Animation>();
    }
    private void Update()
    {
        Move();
        SetAnimation();
    }

    private void Move()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        r = Input.GetAxis("Mouse X");

        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);
        // transform.forward

        if (moveDir.sqrMagnitude > 1)
            moveDir.Normalize();

        transform.Translate(moveDir * moveSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime * r);
    }

    private void SetAnimation()
    {
         if(v >= 0.1f)
         {
            animation.CrossFade("RunF", 0.3f);
         }
        else if (v <= -0.1f)
        {
            animation.CrossFade("RunB", 0.3f);
        }
        else if (h >= 0.1f)
        {
            animation.CrossFade("RunR", 0.3f);
        }
        else if (h <= -0.1f)
        {
            animation.CrossFade("RunL", 0.3f);
        }
    }
}
