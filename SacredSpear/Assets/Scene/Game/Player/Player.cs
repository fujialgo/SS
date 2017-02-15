using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public GameObject bullet;
    private Weapon weapon;

	private bool click_flag =true;

    void Start()
    {
    }
		
	void Ray(){
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

		float maxDistance = 10;
		RaycastHit2D hit = Physics2D.Raycast ((Vector2)ray.origin, (Vector2)ray.direction, maxDistance, 1);

		if (hit.collider) {
			if (hit.collider.gameObject.name == "Cant_Weapon") {
				click_flag = false;
			}
		} else {
			click_flag = true;
		}
	}

	void Player_Angle(){

		Ray ();

		Ray m_ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		Vector3 m_mousePos = m_ray.origin;
		Vector3 m_diff = m_mousePos - transform.position;
		Vector3 m_norm = m_diff.normalized;

		// マウスの方向を向かせる
		float deg = Mathf.Atan2 (m_diff.y, m_diff.x) * Mathf.Rad2Deg;
		transform.eulerAngles = new Vector3 (0, 0, deg - 90);

		if (transform.eulerAngles.z >= 160 && transform.eulerAngles.z <= 360) {
			transform.eulerAngles= new Vector3(0,0,160);
		}

		if (transform.eulerAngles.z >= 0 && transform.eulerAngles.z <= 60) {
			transform.eulerAngles= new Vector3(0,0,60);
		}
	}

		
    void Update()
	{

		Debug.Log (transform.eulerAngles);

		Player_Angle ();
		
		GameInfo info = GameInfo.mInstance;
		if (info.mIsPause == true) {
			return;
		}

		if(click_flag==true){
		if (Input.GetMouseButtonDown (0)) {
			var obj = Instantiate (bullet, transform.position, Quaternion.identity) as GameObject;
			obj.transform.eulerAngles = transform.eulerAngles;

			weapon = GetComponent<Weapon> ();
			obj.GetComponent<Spear> ().m_power = (int)weapon.m_level;
			}
		} 
	}
}
