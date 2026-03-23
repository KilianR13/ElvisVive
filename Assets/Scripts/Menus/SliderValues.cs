using UnityEngine;
using UnityEngine.UI;

public class SliderValues : MonoBehaviour
{

    public float sensitivityValue;

    public Slider sliderSensitivity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sliderSensitivity.onValueChanged.AddListener (delegate {ValueChangeCheck ();});
        sensitivityValue = sliderSensitivity.value;
    }

    public void ValueChangeCheck()
    {
        sensitivityValue = sliderSensitivity.value;
    }

}
