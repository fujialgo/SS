using UnityEngine;
using System.Collections;

public class DoFadeOut : MonoBehaviour {
    [SerializeField]
    FadeManager m_fade;

    void Awake()
    {
        m_fade.mFadeOut();
    }

}
