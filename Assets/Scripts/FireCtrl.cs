using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl : MonoBehaviour
{
    private GameObject bulletPrefab;
    private Transform firePos;    

    private void Awake()
    {
        bulletPrefab = Resources.Load<GameObject>("Prefabs/Bullet");

        Transform[] children = GetComponentsInChildren<Transform>();

        foreach(Transform child in children)
        {
            if (child.name == "FirePos")
                firePos = child;
        }

        BulletManager.instance.AddBullet("PlayerBullet", 30);
        ParticleManager.instance.CreateParticle();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Fire();
        }        
    }

    private void Fire()
    {
        BulletManager.instance.Fire("PlayerBullet", firePos);
        ParticleManager.instance.Play("MuzzleFlash", firePos);
    }
}
