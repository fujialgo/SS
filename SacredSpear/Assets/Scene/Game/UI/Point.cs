using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Point : MonoBehaviour {

    public int mPoint
    {
        get; set;
    }
	// Use this for initialization
	void Start () {
        mPoint = 0;
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Text>().text = "Point:" + mPoint.ToString();
	}

}
