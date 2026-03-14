using UnityEngine;

public class IndicatorLogic : MonoBehaviour
{

    public GameObject jugador;
    public bool alreadyTalkedToAlcalde, alreadyTalkedToSergey, alreadyTalkedToLulu, alreadyTalkedToParsifal;

    public bool alreadyBeatenPaqui, alreadyBeatenCigala, alreadyBeatenFari;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        jugador = this.gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        if (jugador.GetComponent<EventsTriggeredByPlayer>().TriggerAlcalde == true && !alreadyTalkedToAlcalde)
        {
            this.gameObject.GetComponent<ArrowLookAtObjective>().objetivo = this.gameObject.GetComponent<Objetivos>().objetivos[1];

            alreadyTalkedToAlcalde = true;
        }

        if (jugador.GetComponent<EventsTriggeredByPlayer>().TriggerSergey == true && !alreadyTalkedToSergey)
        {
            this.gameObject.GetComponent<ArrowLookAtObjective>().objetivo = this.gameObject.GetComponent<Objetivos>().objetivos[2];

            alreadyTalkedToSergey = true;
        }

            if (this.gameObject.GetComponent<Objetivos>().objetivos[2].GetComponent<BossesStats>().vidas <= 0 && !alreadyBeatenPaqui)
            {
                this.gameObject.GetComponent<ArrowLookAtObjective>().objetivo = this.gameObject.GetComponent<Objetivos>().objetivos[3];

                alreadyBeatenPaqui = true;

                Debug.Log("No deberia entrar aqui más de una vez");
            }
        

        
        if (jugador.GetComponent<EventsTriggeredByPlayer>().TriggerLulu == true && !alreadyTalkedToLulu)
        {
            this.gameObject.GetComponent<ArrowLookAtObjective>().objetivo = this.gameObject.GetComponent<Objetivos>().objetivos[4];

            alreadyTalkedToLulu = false;
        }

        
            if (this.gameObject.GetComponent<Objetivos>().objetivos[4].GetComponent<BossesStats>().vidas <= 0 && !alreadyBeatenCigala)
            {


                this.gameObject.GetComponent<ArrowLookAtObjective>().objetivo = this.gameObject.GetComponent<Objetivos>().objetivos[5];

                alreadyBeatenCigala = false;
            }
        

        if (jugador.GetComponent<EventsTriggeredByPlayer>().TriggerParsifal == true && !alreadyTalkedToParsifal)
        {
            this.gameObject.GetComponent<ArrowLookAtObjective>().objetivo = this.gameObject.GetComponent<Objetivos>().objetivos[6];

            alreadyTalkedToParsifal = false;
        }

       
            if (this.gameObject.GetComponent<Objetivos>().objetivos[6].GetComponent<BossesStats>().vidas <= 0)
            {
                this.gameObject.GetComponent<ArrowLookAtObjective>().objetivo = this.gameObject.GetComponent<Objetivos>().objetivos[7];
            }
        

        
    }
}
