using UnityEngine;

public class ConfigValues : MonoBehaviour
{

    public static ConfigValues instance;

    public float sensitivity;

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
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        sensitivity = this.gameObject.GetComponent<SliderValues>().sensitivityValue + 0.1f;
    }
}
