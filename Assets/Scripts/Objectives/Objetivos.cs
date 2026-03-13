using System.Collections.Generic;
using UnityEngine;

public class Objetivos : MonoBehaviour
{
    public List<GameObject> objetivos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.gameObject.GetComponent<ArrowLookAtObjective>().objetivo = objetivos[0];
    }

    // Update is called once per frame
    void Update()
    {

        if(objetivos[2].GetComponent<BossesStats>().vidas == 0)
        {
            this.gameObject.GetComponent<ArrowLookAtObjective>().objetivo = objetivos[3];
        }

        if (objetivos[4].GetComponent<BossesStats>().vidas == 0)
        {
            this.gameObject.GetComponent<ArrowLookAtObjective>().objetivo = objetivos[5];
        }

        if (objetivos[6].GetComponent<BossesStats>().vidas == 0)
        {
            this.gameObject.GetComponent<ArrowLookAtObjective>().objetivo = objetivos[7];
        }
    }
}
