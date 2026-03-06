using UnityEngine;

public class BossesStats : MonoBehaviour
{

    public int vidas;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (vidas == 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {

        Debug.Log("TriggerEnter Boss");

        if(other.gameObject.CompareTag("Onda"))
        {
            Debug.Log("Daño a jefe");
            vidas--;

            Destroy(other.gameObject);
        }
    }
}
