using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpriteChange : MonoBehaviour {
    [SerializeField]
    Sprite m_image;

    [SerializeField]
    string m_changedText;

    public void mSpriteChange()
    {
        var img = GetComponent<Image>().sprite;
        GetComponent<Image>().sprite = m_image;
        m_image = img;
    }

    public void mTextChange()
    {
        var txt = GetComponentInChildren<Text>().text;
        GetComponentInChildren<Text>().text = m_changedText;
        m_changedText = txt;

    }
}
