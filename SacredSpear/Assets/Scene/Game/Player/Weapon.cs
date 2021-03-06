﻿using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	[SerializeField]
	private ButtonStateChange m_PowerUp;

    [SerializeField]
    private Point m_pointObj;
    private float m_PowerPoint =100.0f;
    private float m_PowerMagnification = 1.0f;
    public float m_level =0;
	public bool m_power_flag;

	[SerializeField]
	private SpriteChange m_Weapon;


    // Use this for initialization
    void Start () {
		m_power_flag = false;
	}
	
	// Update is called once per frame
	void Update () {
		IfuseCheck ();
	}

#if UNITY_EDITOR
    //Editor 用デバッグ
    void OnGUI() {
        GUI.Box(new Rect(20, 100, 60, 30), m_level.ToString("#.#"));
    }
#endif

    public void mWeaponPowerUp()
    {
        float powerpoint = m_PowerPoint * m_PowerMagnification;
        if (m_pointObj.mPoint > (int)powerpoint)
        {
			m_Weapon.GetComponent<SpriteChange>().mSpriteChange();
			m_Weapon.GetComponent<SpriteChange>().mTextChange();
            m_pointObj.mPoint -= (int)powerpoint;
            m_level *= 1.8f;
            m_PowerMagnification *= 2.5f;
			m_power_flag = true;
        }
    }
		
	void IfuseCheck()
	{
		if (m_PowerPoint * m_PowerMagnification < m_pointObj.mPoint)
		{
			m_PowerUp.GetComponent<ButtonStateChange> ().mSetInteractable (true);
		}else{
			m_PowerUp.GetComponent<ButtonStateChange>().mSetInteractable(false);
		}
	}
}
