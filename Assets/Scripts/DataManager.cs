using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct CharacterData
{
    public int key;
    public int nameKey;
    public int explaneKey;
    public int hp;
    public int attack;
    public string prefab;
    public string icon;
}

public class DataManager : MonoBehaviour
{
    //static public DataManager instance;
    static private DataManager _instance;

    static public DataManager instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject obj = new GameObject("DataManager");
                _instance = obj.AddComponent<DataManager>();
            }

            return _instance;
        }
    }

    private void Awake()
    {
        //instance = this;

        LoadTextData();
        LoadCharacterData();
    }

    public Dictionary<int, string> textData = new Dictionary<int, string>();
    public Dictionary<int, CharacterData> characterData = new Dictionary<int, CharacterData>();

    private void LoadTextData()
    {
        TextAsset textAsset = Resources.Load<TextAsset>("TextData/TextTable");

        string temp = textAsset.text.Replace("\r\n", "\n");

        string[] row = temp.Split('\n');

        for(int i = 1; i < row.Length; i++)
        {
            string[] data = row[i].Split('\t');

            if (data.Length <= 1) continue;

            int key = int.Parse(data[0]);

            if (Application.systemLanguage == SystemLanguage.Korean)
                textData.Add(key, data[1]);
            else
                textData.Add(key, data[2]);
        }
    }

    private void LoadCharacterData()
    {
        TextAsset textAsset = Resources.Load<TextAsset>("TextData/CharacterTable");

        string temp = textAsset.text.Replace("\r\n", "\n");

        string[] row = temp.Split('\n');

        for (int i = 1; i < row.Length; i++)
        {
            string[] data = row[i].Split(',');

            if (data.Length <= 1) continue;

            CharacterData character;
            character.key = int.Parse(data[0]);
            character.nameKey = int.Parse(data[1]);
            character.explaneKey = int.Parse(data[2]);
            character.hp = int.Parse(data[3]);
            character.attack = int.Parse(data[4]);
            character.prefab = data[5];
            character.icon = data[6];

            characterData.Add(character.key, character);
        }
    }
}
