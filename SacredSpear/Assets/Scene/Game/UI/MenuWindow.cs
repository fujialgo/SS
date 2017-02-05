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

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void mOpen()
    {
        transform.DOScaleY(1, 0.2f).OnComplete(()=>
        {
            gameObject.SetActive(true);
            m_contents.SetActive(true);
            Time.timeScale = 0;
        });
       
    }


    public void mClose()
    {
        transform.DOScaleY(0, 0.2f).OnStart(() => 
        {
            gameObject.SetActive(false);
            m_contents.SetActive(false);
            Time.timeScale = 1;
        });
    }

}
