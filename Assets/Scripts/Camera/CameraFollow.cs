using UnityEngine;
using VicGenLib.Canvas;

public class CameraFollow : MonoBehaviour
{

    public GameObject cameraFollow;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = cameraFollow.transform.position;
    }
}
