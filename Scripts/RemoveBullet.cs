using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBullet : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            collision.gameObject.SetActive(false);
            /*
            Debug.Log("Hello");
            Destroy(collision.gameObject);
            */
        }
    }
}
