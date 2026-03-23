using System;
using TMPro;
using UnityEngine;

public class MenuText : MonoBehaviour
{

    public ConfigValues configValues;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!configValues)
        {
            configValues = GameObject.Find("ConfigValues").GetComponent<ConfigValues>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = $"Sensitivity {Math.Round(configValues.sensitivity, 2)}";
    }
}
