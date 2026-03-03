using UnityEngine;

public class ChangeMode : MonoBehaviour
{

    public GameObject camara3th;

    public GameObject camaraFPS;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            if (camaraFPS.activeSelf)
            {
                camara3th.SetActive(true);
                camaraFPS.SetActive(false);
            }

            else
            {
                camara3th.SetActive(false);
                camaraFPS.SetActive(true);
            }
            
        }
    }
}
