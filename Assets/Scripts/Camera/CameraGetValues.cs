using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class CameraGetValues : MonoBehaviour
{

    public GameObject config;
    private bool configFound;

    public CinemachineInputAxisController ThisAxisController;

    public GameObject player;

    private float Xsens, Ysens;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (GameObject.Find("ConfigValues") != null)
        {
            config = GameObject.Find("ConfigValues");
            configFound = true;
        }
        else
        {
            configFound = false;
        }

        Xsens = ThisAxisController.Controllers[0].Input.Gain;

        Ysens = ThisAxisController.Controllers[1].Input.Gain;
    }

    // Update is called once per frame
    void Update()
    {
        if (!configFound) return;
        //primer apartado, Gain
        ThisAxisController.Controllers[0].Input.Gain = Xsens * config.GetComponent<ConfigValues>().sensitivity;
        ThisAxisController.Controllers[1].Input.Gain = Ysens * config.GetComponent<ConfigValues>().sensitivity;
        //config.GetComponent<ConfigValues>().sensitivity;
    }
}
