using UnityEngine;
using System.Collections;
using DG.Tweening;
public class MenuWindow : MonoBehaviour {

    [SerializeField]
    GameObject m_contents;


    const float mkAnimateTime = 0.2f;
    //初期化
    void Awake()
    {
        m_contents.SetActive(false);
        gameObject.SetActive(true);
    }


    public void mOpen()
    {
        transform.DOScaleY(1, mkAnimateTime)
            
            .OnStart(() => {
                gameObject.SetActive(true);
                GameInfo.mInstance.mIsPause = true;
            })
            
            .OnComplete(()=>     {
                m_contents.SetActive(true);
                Time.timeScale = 0;
        });
       
    }


    public void mClose()
    {
        transform.DOScaleY(0, mkAnimateTime)
            
            .OnStart(() => {
                m_contents.SetActive(false);
                Time.timeScale = GameInfo.mInstance.mGameSpeed;
        })
            .OnComplete(() => {
                gameObject.SetActive(false);
                GameInfo.mInstance.mIsPause = false;
        });
    }

}
