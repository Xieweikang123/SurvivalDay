using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadNewScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //异步加载新场景
    public void Load_NewScene()
    {
        //保存要加载的目标场景
        Globe.nextSceneName = "C";

        SceneManager.LoadSceneAsync("B");
    }
}
