using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    private ParticleSystem particleSystem;

    private float playTime = 0.0f;
    private Transform parentTrans;
    private void Awake()
    {
        particleSystem = GetComponent<ParticleSystem>();
        playTime = particleSystem.main.duration;
        parentTrans = transform.parent;
    }

    private void OnEnable()
    {
        StartCoroutine(DisableParticle());
    }

    private IEnumerator DisableParticle()
    {
        yield return new WaitForSeconds(playTime);

        transform.parent = parentTrans;
        gameObject.SetActive(false);
    }
}
