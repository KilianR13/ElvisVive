using UnityEngine;

public class Notes : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Onda") && other.gameObject.GetComponent<AttackType>().metal)
        {
            Destroy(this.gameObject);
        }
    }
}
