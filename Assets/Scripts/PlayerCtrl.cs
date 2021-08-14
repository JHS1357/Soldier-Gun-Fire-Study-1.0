using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerCtrl : MonoBehaviour
{
    [SerializeField]
    protected float walkSpeed = 5.0f;
    [SerializeField]
    protected float runSpeed = 10.0f;

    [SerializeField]
    protected float rotSpeed = 5.0f;

    protected float moveSpeed = 0;

    protected float h = 0.0f;
    protected float v = 0.0f;
    protected float r = 0.0f;

    protected bool isRun = false;
    protected Vector3 moveDir;

    protected void Update()
    {
        Move();
        SetAnimation();
    }

    private void Move()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        r = Input.GetAxis("Mouse X");

        moveDir = (Vector3.forward * v) + (Vector3.right * h);

        if (moveDir.sqrMagnitude > 1)
            moveDir.Normalize();

        isRun = Input.GetKey(KeyCode.LeftShift);

        moveSpeed = isRun ? runSpeed : walkSpeed;

        transform.Translate(moveDir * moveSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime * r);
    }

    protected abstract void SetAnimation();
}
