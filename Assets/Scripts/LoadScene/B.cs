﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Globe
{
    public static string nextSceneName;
}
public class B : MonoBehaviour {

    public Slider loadingSlider;
    public Text loadingText;

    private float targetValue;
    private float loadingSpeed = 1;
    private AsyncOperation operation;

	// Use this for initialization
	void Start () {
        loadingSlider.value = 0.0f;

        if (SceneManager.GetActiveScene().name == "B")
        {
            //启动协程
            StartCoroutine(AsyncLoading());
        }
	}
	
	// Update is called once per frame
	void Update () {
        targetValue = operation.progress;

        if (operation.progress >= 0.9f)
        {
            //operation.progress的值最大为0.9
            targetValue = 1.0f;
        }

        if (targetValue != loadingSlider.value)
        {
            //差值运算
            loadingSlider.value = Mathf.Lerp(loadingSlider.value, targetValue, Time.deltaTime * loadingSpeed);

            if (Mathf.Abs(loadingSlider.value - targetValue) < 0.01f)
            {
                loadingSlider.value = targetValue;
            }
        }

        loadingText.text=((int)(loadingSlider.value*100)).ToString()+"%";

        if (((int)loadingSlider.value * 100) == 100)
        {
            //允许异步加载完毕后自动切换场景
            operation.allowSceneActivation = true;
            
        }
	}

    IEnumerator AsyncLoading()
    {
        operation = SceneManager.LoadSceneAsync(Globe.nextSceneName);
        //阻止当加载完成自动切换
        operation.allowSceneActivation = false;

        yield return operation;
    }
}
