using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonStateChange : MonoBehaviour {

    Button m_button;
	// Use this for initialization
	void Start () {
        m_button = this.GetComponent<Button>();
	}
	
    public void mSetInteractable(bool flg)
    {
        m_button.interactable = flg;
    }
}
