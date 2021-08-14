using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    public float speed = 1000.0f;

    private Rigidbody rd;
    private TrailRenderer trailRenderer;

    private void Awake()
    {
        rd = GetComponent<Rigidbody>();
        trailRenderer = GetComponent<TrailRenderer>();
    }

    private void OnEnable()
    {
        rd.velocity = Vector3.zero;
        rd.angularVelocity = Vector3.zero;

        trailRenderer.Clear();

        rd.AddForce(transform.forward * speed);
    }
}
