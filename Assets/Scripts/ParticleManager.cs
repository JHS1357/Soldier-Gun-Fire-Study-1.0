using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    static private ParticleManager _instance;

    static public ParticleManager instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject obj = new GameObject("ParticleManager");
                _instance = obj.AddComponent<ParticleManager>();
            }

            return _instance;
        }
    }

    private Dictionary<string, List<GameObject>> totalParticle = new Dictionary<string, List<GameObject>>();

    public void CreateParticle()
    {
        AddParticle("MuzzleFlash", 20);
        AddParticle("SmallExplosion", 30);
    }

    private void AddParticle(string key, int poolCount = 50)
    {
        GameObject prefab = Resources.Load<GameObject>("Prefabs/Particles/" + key);

        List<GameObject> particles = new List<GameObject>();
        for(int i = 0; i < poolCount; i++)
        {
            GameObject particle = Instantiate(prefab, transform);
            particle.AddComponent<Particle>();
            particle.SetActive(false);
            particle.name = key + "_" + i;

            particles.Add(particle);
        }

        totalParticle.Add(key, particles);
    }

    public void Play(string key, Transform trans)
    {
        if (!totalParticle.ContainsKey(key)) return;

        List<GameObject> particles = totalParticle[key];

        foreach(GameObject particle in particles)
        {
            if(!particle.activeSelf)
            {
                particle.transform.SetParent(trans);
                particle.transform.localPosition = Vector3.zero;
                particle.transform.localRotation = Quaternion.identity;
                particle.SetActive(true);
                return;
            }
        }
    }

    public void Play(string key, Vector3 pos, Quaternion rot)
    {
        if (!totalParticle.ContainsKey(key)) return;

        List<GameObject> particles = totalParticle[key];

        foreach (GameObject particle in particles)
        {
            if (!particle.activeSelf)
            {
                particle.transform.position = pos;
                particle.transform.rotation = rot;
                particle.SetActive(true);
                return;
            }
        }
    }
}
