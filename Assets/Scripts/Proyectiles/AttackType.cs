using UnityEngine;

public class AttackType : MonoBehaviour
{

    public bool metal;
    public bool dodecafonico;
    public bool leifmotif;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(dodecafonico)

        if(leifmotif)
        {
            
        }
        
    }

    void OnCollisionEnter(Collision other)
    {

        Debug.Log("Trigger ataque");

        if (other.gameObject.CompareTag("Nota"))
        {

            

            if(metal)
            Destroy(other.gameObject);
        }
    }
}
