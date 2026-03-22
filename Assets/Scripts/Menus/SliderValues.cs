using UnityEngine;
using UnityEngine.UI;

public class SliderValues : MonoBehaviour
{

    public float sensitivityValue;

    public GameObject sliderSensitivity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sliderSensitivity = GameObject.Find("SliderSen");
    }

    // Update is called once per frame
    void Update()
    {
        if (sliderSensitivity != null)
        {
            sensitivityValue = sliderSensitivity.GetComponent<Slider>().value;
        }
    }
}
