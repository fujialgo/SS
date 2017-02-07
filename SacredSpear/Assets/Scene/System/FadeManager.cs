using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.Events;
public class FadeManager : MonoBehaviour {

    [SerializeField]
    UnityEvent m_in = new UnityEvent();
    [SerializeField]
    UnityEvent m_out = new UnityEvent();

    const float mkFadeTime = 1.0f;

    public void mFadeIn()
    {
        DOTween.To(() => transform.GetComponentInChildren<Image>().color,
                        x => transform.GetComponentInChildren<Image>().color = x,
                        new Color(0, 0, 0, 1),mkFadeTime).

                        OnComplete(() => {
                            m_in.Invoke();
                        }); 
    }

    public void mFadeOut()
    {
        DOTween.To(() => transform.GetComponentInChildren<Image>().color,
                        x => transform.GetComponentInChildren<Image>().color = x,
                        new Color(0, 0, 0, 0), mkFadeTime).

                        OnComplete(() => {
                            m_out.Invoke();
                        });
    }


}   
