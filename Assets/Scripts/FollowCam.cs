using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public float moveDamping = 15.0f;

    public float distance = 5.0f;
    public float height = 4.0f;
    public float targetOffset = 2.0f;

    private Transform target;

    private void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    private void LateUpdate()
    {
        Vector3 camPos = target.position - (target.forward * distance) + (target.up * height);

        transform.position = Vector3.Slerp(transform.position, camPos, Time.deltaTime * moveDamping);

        transform.LookAt(target.position + (target.up * targetOffset));
    }

    private void OnDrawGizmos()
    {
        if (target == null) return;

        Gizmos.color = Color.green;

        Vector3 lookAtPos = target.position + (target.up * targetOffset);

        Gizmos.DrawWireSphere(lookAtPos, 0.1f);
        Gizmos.DrawLine(lookAtPos, transform.position);
    }
}
