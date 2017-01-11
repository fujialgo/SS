using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public float mScore
    {
        get; set;
    }
	// Use this for initialization
	void Start () {
        mScore = 0;
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Text>().text = "Score:" + mScore;
	}
}
