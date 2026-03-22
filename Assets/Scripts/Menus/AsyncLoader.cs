using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AsyncLoader : MonoBehaviour
{
    [Header("Menu Screens")]
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private GameObject mainMenu;

    [Header("Slider")]
    [SerializeField] private Slider loadingSlider;

    public bool configActiva;

    public GameObject config;

    void Awake()
    {
        config = GameObject.Find("Opciones");
    }

    void Start()
    {
        config.gameObject.SetActive(false);
    }

    public void LoadLevelBttn(string levelName)
    {
        mainMenu.SetActive(false);
        loadingScreen.SetActive(true);
        StartCoroutine(LoadLevelAsync(levelName));
    }

    public void Opciones()
    {
        configActiva = !configActiva;

        if (configActiva == false)
        {
            config.gameObject.SetActive(false);
        }

        else
        {
            config.gameObject.SetActive(true);
        }
    }

    IEnumerator LoadLevelAsync(string levelName)
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(levelName);

        while (!loadOperation.isDone)
        {
            float progressValue = Mathf.Clamp01(loadOperation.progress / 0.9f);
            loadingSlider.value = progressValue;
            yield return null;
        }

    }



    // [SerializeField] private GameObject loadingScreen;
    // [SerializeField] private GameObject loadingScreen;
    // [SerializeField] private GameObject loadingScreen;
    // [SerializeField] private GameObject loadingScreen;
}
