using UnityEngine;

public class PlayerPositionFix : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            Debug.Log("tecla");
            this.gameObject.transform.localPosition = new Vector3(0,1,0);
        }
    }
}
