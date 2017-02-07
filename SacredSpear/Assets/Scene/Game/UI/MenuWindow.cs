using UnityEngine;
using System.Collections;
using DG.Tweening;
public class MenuWindow : MonoBehaviour {

    [SerializeField]
    GameObject m_contents;

    //初期化
    void Awake()
    {
        transform.localScale = new Vector3(1, 0, 1);
        m_contents.SetActive(false);
        gameObject.SetActive(false);

    }


    public void mOpen()
    {
        transform.DOScaleY(1, 0.2f)
            
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
        transform.DOScaleY(0, 0.2f)
            
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
