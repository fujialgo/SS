using UnityEngine;
using System;


public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T m_instance;
    public static T mInstance
    {
        get
        {
            if (m_instance == null)
            {
                Type t = typeof(T);

                m_instance = (T)FindObjectOfType(t);
                if (m_instance == null)
                {
                }
            }

            return m_instance;
        }
    }

    virtual protected void Awake()
    {
        if (this != mInstance)
        {
            Destroy(this);
            //Destroy(this.gameObject);
            return;
        }

        // なんとかManager的なSceneを跨いでこのGameObjectを有効にしたい場合は
        // ↓コメントアウト外してください.
        //DontDestroyOnLoad(this.gameObject);
    }

}