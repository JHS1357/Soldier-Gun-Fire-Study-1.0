using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    static private BulletManager _instance;

    static public BulletManager instance
    {
        get
        {
            if(_instance == null)
            {
                GameObject obj = new GameObject("BulletManager");
                _instance = obj.AddComponent<BulletManager>();
            }

            return _instance;
        }
    }

    private Dictionary<string, List<GameObject>> totalBullet = new Dictionary<string, List<GameObject>>();
    //자료 구조
    //단순 자료 구조 / 복합 자료 구조

    public void AddBullet(string key, int poolCount = 50)
    {
        GameObject prefab = Resources.Load<GameObject>("Prefabs/" + key);

        List<GameObject> bullets = new List<GameObject>();

        for(int i = 0; i < poolCount; i++)
        {
            GameObject bullet = Instantiate(prefab, transform);
            bullet.SetActive(false);
            bullet.name = key + "_" + i;

            bullets.Add(bullet);
        }

        totalBullet.Add(key, bullets);
    }
    public void Fire(string key, Transform trans)
    {
        if (!totalBullet.ContainsKey(key)) return;

        List<GameObject> bullets = totalBullet[key];

        foreach(GameObject bullet in bullets)
        {
            if(!bullet.activeSelf)
            {
                bullet.transform.position = trans.position;
                bullet.transform.rotation = trans.rotation;
                bullet.SetActive(true);

                return;
            }
        }
    }

}
