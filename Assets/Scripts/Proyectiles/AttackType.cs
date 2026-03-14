using System.Collections;
using UnityEngine;

public class AttackType : MonoBehaviour
{

    public bool metal; //manejado en el script de notas
    public bool dodecafonico;
    public bool leifmotif;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(NoteLifeSpan());
    }

    // Update is called once per frame
    void Update()
    {

        if(dodecafonico)

        if(leifmotif)
        {
            
        }
        
    }

    IEnumerator NoteLifeSpan()
    {
        yield return new WaitForSecondsRealtime(10f);
        Destroy(gameObject);
    }
}
