using UnityEngine;

public class ArrowLookAtObjective : MonoBehaviour
{

    public GameObject objetivo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.LookAt(objetivo.transform);
    }
}
