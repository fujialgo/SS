using UnityEngine;
using System.Collections;

public class TheWorld : MonoBehaviour {

	private bool world_flag;

	[SerializeField]
	private Point m_pointObj;

	// Use this for initialization
	void Start () {
		world_flag = false;
	}
		
	// Update is called once per frame
	void Update () {

		if(world_flag ==true){
			m_pointObj.mPoint -= 2;
		}


		if (m_pointObj.mPoint <= 0) {
			GameInfo info = GameInfo.mInstance;
			Time.timeScale = info.mGameSpeed;
			world_flag = false;
			m_pointObj.mPoint = 0;

		}
			

		if (Input.GetMouseButtonDown (1)) {
			if (world_flag == false) {
				Time.timeScale = 0.1f;
				world_flag = true;
			} else if (world_flag == true) {
				GameInfo info = GameInfo.mInstance;
				Time.timeScale = info.mGameSpeed;
				world_flag = false;
			}
		}
	}

}