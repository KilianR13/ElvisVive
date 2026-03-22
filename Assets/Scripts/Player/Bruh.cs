using UnityEngine;

public class Bruh : MonoBehaviour
{

    public float valor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            valor++;
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            valor--;
        }

    }
}
