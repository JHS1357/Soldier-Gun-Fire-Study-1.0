using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager instance;
    
    public Transform startPos;

    public int selectPlayerNum = 1;
        
    private GameObject _player;
    public GameObject player
    {
        get
        {
            return _player;
        }
    }



    private void Awake()
    {
        instance = this;

        CreatePlayer();
    }

    private void CreatePlayer()
    {
        CharacterData data = DataManager.instance.characterData[selectPlayerNum];

        GameObject prefab = Resources.Load<GameObject>(data.prefab);

        _player = Instantiate(prefab, startPos.position, startPos.rotation);
    }
}
