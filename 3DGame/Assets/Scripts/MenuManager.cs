﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;


public class MenuManager : MonoBehaviour
{
    [Header("載入畫面")]
    public GameObject panelLoading;
    [Header("載入畫面文字")]
    public Text textLoading;
    [Header("載入畫面讀條")]
    public Image imgLoading;


   
    public void StartLoading()
    {
        print("開始載入....");
        panelLoading.SetActive(true);
       
        //SceneManager.LoadScene("關卡1");
        StartCoroutine(Loading());
    }

    /// <summary>
    /// 協程方法:載入
    /// </summary>
    /// <returns></returns>
    public IEnumerator Loading()
    {
       AsyncOperation ao = SceneManager.LoadSceneAsync("關卡1");

        ao.allowSceneActivation = false; //是否自動載入畫面 = 否
        while (ao.progress < 1)
        {
            print("關卡進度" + ao.progress);
            yield return null;

            textLoading.text = (ao.progress / 0.9 * 100).ToString("F2") + "  %";
            imgLoading.fillAmount = ao.progress;

            if (ao.progress == 0.9f)
            ao.allowSceneActivation = true;
        }
    }
    private void Start()
    {
        Screen.SetResolution(768, 1024, false);  //螢幕.設定解析度
    }
}
