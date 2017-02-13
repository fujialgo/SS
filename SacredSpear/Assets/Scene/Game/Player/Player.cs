using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public GameObject bullet;
    private Weapon weapon;

    void Start()
    {
    }
		
    void Update()
	{
		Ray m_ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		Vector3 m_mousePos = m_ray.origin;
		Vector3 m_diff = m_mousePos - transform.position;
		Vector3 m_norm = m_diff.normalized;

		// マウスの方向を向かせる
		float deg = Mathf.Atan2 (m_diff.y, m_diff.x) * Mathf.Rad2Deg;
		transform.eulerAngles = new Vector3 (0, 0, deg - 90);

		GameInfo info = GameInfo.mInstance;
		if (info.mIsPause == true) {
			return;
		}
			
		if (Input.GetMouseButtonDown (0)) {
			var obj = Instantiate (bullet, transform.position, Quaternion.identity) as GameObject;
			obj.transform.eulerAngles = transform.eulerAngles;

			weapon = GetComponent<Weapon> ();
			obj.GetComponent<Spear> ().m_power = (int)weapon.m_level;
			Debug.Log (obj.GetComponent<Spear> ().m_power);
		} 
	}
}
