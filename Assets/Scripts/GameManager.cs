using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager instance;

    public Transform startPos;

    public int selectPlayerNum = 1;
    public GameObject player;

    private void Awake()
    {
        instance = this;

        CreatePlayer();
    }

    private void CreatePlayer()
    {
        CharacterData data = DataManager.instance.characterData[selectPlayerNum];

        GameObject prefab = Resources.Load<GameObject>(data.prefab);

        player = Instantiate(prefab, startPos.position, startPos.rotation);
    }
}
