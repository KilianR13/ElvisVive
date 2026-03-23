using UnityEngine;

public class ConfigValues : MonoBehaviour
{

    public static ConfigValues instance;

    public float sensitivity;
    private float tempSensitivity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        tempSensitivity = gameObject.GetComponent<SliderValues>().sensitivityValue;
        if (tempSensitivity <= 0.1f)
        {
            tempSensitivity = 0.1f;
        }
        else
        {
            sensitivity = tempSensitivity;    
        }
        
    }
}
