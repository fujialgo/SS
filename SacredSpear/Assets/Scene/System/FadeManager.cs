using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.Events;
public class FadeManager : MonoBehaviour {

    [SerializeField]
    UnityEvent m_begin = new UnityEvent();
    [SerializeField]
    UnityEvent m_end = new UnityEvent();

    const float mkFadeTime = 1.0f;

    public void mFadeIn()
    {
        DOTween.To(() => transform.GetComponent<Image>().color,
                        x => transform.GetComponent<Image>().color = x,
                        new Color(0, 0, 0, 1),mkFadeTime).

                        OnComplete(() => {
                            m_begin.Invoke();
                        }); 
    }

    public void mFadeOut()
    {
        DOTween.To(() => transform.GetComponent<Image>().color,
                        x => transform.GetComponent<Image>().color = x,
                        new Color(0, 0, 0, 0), mkFadeTime).

                        OnComplete(() => {
                            m_end.Invoke();
                        });
    }


}   
