using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    public void mSceneLoad(string str)
    {
        SceneManager.LoadScene(str);
    }

}
