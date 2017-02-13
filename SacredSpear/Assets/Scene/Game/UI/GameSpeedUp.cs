using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameSpeedUp : MonoBehaviour {

    Text text;

    [SerializeField]
    float m_maxSpeed;

    void Start() {
        text = GetComponentInChildren<Text>();
    }

    void Update() {
        if (GameInfo.mInstance.mIsPause) return;

        text.text = "x" + GameInfo.mInstance.mGameSpeed.ToString("#");


    }


    public void OnClick()
    {
        float speed = GameInfo.mInstance.mGameSpeed;

        if (speed >= m_maxSpeed){
            speed = 0.0f;
        }
        speed += 1.0f;

        Time.timeScale = speed;
        GameInfo.mInstance.mGameSpeed = speed;
    }

}
