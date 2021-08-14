using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectManager : MonoBehaviour
{
    public static SelectManager instance;

    private Transform contentTrans;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        contentTrans = GameObject.Find("Content").transform;

        CreateCharacterBtn();
    }

    private void CreateCharacterBtn()
    {
        GameObject btnPrefab = Resources.Load<GameObject>("Prefabs/CharacterBtn");

        Dictionary<int, CharacterData> datas = DataManager.instance.characterData;

        foreach(KeyValuePair<int, CharacterData> data in datas)
        {
            GameObject btn = Instantiate(btnPrefab, contentTrans);
            btn.GetComponent<CharacterBtn>().SetData(data.Key);
        }
    }
}
