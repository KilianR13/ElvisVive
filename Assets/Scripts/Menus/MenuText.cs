using System;
using TMPro;
using UnityEngine;

public class MenuText : MonoBehaviour
{

    public GameObject configValues;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        configValues = GameObject.Find("ConfigValues");
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<TextMeshProUGUI>().text = $"Sensitivity {Math.Round(configValues.GetComponent<ConfigValues>().sensitivity, 2)}";
    }
}
