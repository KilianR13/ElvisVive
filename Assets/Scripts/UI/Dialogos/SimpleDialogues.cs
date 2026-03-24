using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;

public class SimpleDialogues : MonoBehaviour
{
    public List<string> dialogos;

    public GameObject player;

    public bool AlrTalkedWithAlcalde, AlrTalkedWithSergey, AlrTalkedWithLulu, AlrTalkedWithParsifal;
    public bool assigned;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        dialogos[0] = "¡Tienes que ayudarnos! \n¡El Fari, Cigala y Paquirrin tienen encerrado a Elvis! \nTu parece que aprecias la buena música \nNuestro pueblo está tomado por Paquirrín \n¡liberanos, por favor!";

        dialogos[1] = "Oye chico, creo que tienes potencial para poder ayudarnos \nPonemos nuestras esperanzas en ti. \nEsa espada que llevas parece especial, como imbuida en armonía \nprueba a atacar con ella a distancia, a lo mejor hace algún sonido. \nQuizás con el poder de la buena música podamos liberar a Elvis \ny liberar la zona de la antimúsica. \nDeberías empezar con Paquirrín que está aquí en este pueblo \n[Con click izq atacas]";

        dialogos[2] = "¡Necesito tu ayuda! \nEl Cigala está en este bosque, yo sola no puedo contra el. \nPero a lo mejor con tu poder del metal y mis composiciones dodecafonicas \nPodrás derrotar a Cigala \nDeberias probar las composiciones [Con click derecho usas composiciones]";

        dialogos[3] = "Noble guerrero, necesitamos tu ayuda \nEl Fari tiene atrapado a Elvis, necesitarás coraje para derrotarlo \nTu fuerza músical y mis leitmotifs posiblemente le puedan hacer frente al Fari ";

        PrintText();
    }

    private void CheckAndDeleteText()
    {
        if (!this.gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text.Equals(""))
        {
            this.gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "";
        }
    }

    private async UniTaskVoid PrintText()
    {
        if (player.GetComponent<EventsTriggeredByPlayer>().TriggerAlcalde && !AlrTalkedWithAlcalde)
        {

            CheckAndDeleteText();

            this.gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = dialogos[0];

            await UniTask.Delay(8000);

            this.gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "";

            AlrTalkedWithAlcalde = true;
        }

        if (player.GetComponent<EventsTriggeredByPlayer>().TriggerSergey && !AlrTalkedWithSergey)
        {
            CheckAndDeleteText();

            this.gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = dialogos[1];

            await UniTask.Delay(8000);

            this.gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "";

            AlrTalkedWithSergey = true;
        }

        if (player.GetComponent<EventsTriggeredByPlayer>().TriggerLulu && !AlrTalkedWithLulu)
        {

            CheckAndDeleteText();

            this.gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = dialogos[2];

            await UniTask.Delay(8000);

            this.gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "";

            AlrTalkedWithLulu = true;
        }

        if (player.GetComponent<EventsTriggeredByPlayer>().TriggerParsifal && !AlrTalkedWithParsifal)
        {
            CheckAndDeleteText();

            this.gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = dialogos[3];

            await UniTask.Delay(8000);

            this.gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "";

            AlrTalkedWithParsifal = true;
        }
    }
}
