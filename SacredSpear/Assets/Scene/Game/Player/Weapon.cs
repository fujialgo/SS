using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

    [SerializeField]
    private Point m_pointObj;
    private float m_PowerPoint =100.0f;
    private float m_PowerMagnification = 1.0f;
    public int m_speed = 10;
    [SerializeField]
    protected int m_power;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void mWeaponPowerUp()
    {

        float powerpoint = m_PowerPoint * m_PowerMagnification;
        if (m_pointObj.mPoint > (int)powerpoint)
        {
            m_pointObj.mPoint -= (int)powerpoint;
            m_power = m_power*10;
            m_PowerMagnification *= 1.7f;
        }
    }
}
