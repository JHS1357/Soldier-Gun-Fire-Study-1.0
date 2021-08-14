using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterBtn : MonoBehaviour
{
    private Image icon;
    private Text charName;

    private CharacterData data;

    private void Awake()
    {
        icon = transform.GetChild(0).GetComponent<Image>();
        charName = transform.GetChild(1).GetComponent<Text>();
    }

    public void SetData(int key)
    {
        data = DataManager.instance.characterData[key];

        Sprite sprite = Resources.Load<Sprite>("Icons/" + data.icon);
        icon.sprite = sprite;

        charName.text = DataManager.instance.textData[data.nameKey];
    }
}
