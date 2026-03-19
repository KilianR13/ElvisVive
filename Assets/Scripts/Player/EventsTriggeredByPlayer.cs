using TMPro;
using UnityEngine;

public class EventsTriggeredByPlayer : MonoBehaviour
{

    public GameObject soundHandler, canvasDialogos;

    public bool TriggerAlcalde, TriggerSergey, TriggerLulu, TriggerParsifal;

    public bool EstaEnDialogo;

    public bool PressedQ;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        soundHandler = GameObject.Find("SoundHandler");

        canvasDialogos = GameObject.Find("CanvasDialogos");
    }

    // Update is called once per frame
    void Update()
    {
        FastDialogues();

        if (PressedQ)
        {
            canvasDialogos.GetComponent<DialoguesSystem>().printSpeedMultipler = 5;
        }
        else
        {
            canvasDialogos.GetComponent<DialoguesSystem>().printSpeedMultipler = 1;
        }
    }

    private void FastDialogues()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            PressedQ = true;
        }

        if (Input.GetKeyUp(KeyCode.Q))
        {
            PressedQ = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Paquirrin"))
        {
            soundHandler.GetComponent<AudioSource>().clip = soundHandler.GetComponent<AlmacenamientoSonidos>().sonidosPaquirrín[0];

            soundHandler.GetComponent<AudioSource>().Play();
        }

        if (other.gameObject.CompareTag("Cigala"))
        {
            soundHandler.GetComponent<AudioSource>().clip = soundHandler.GetComponent<AlmacenamientoSonidos>().sonidosCigala[0];

            soundHandler.GetComponent<AudioSource>().Play();
        }

        if (other.gameObject.CompareTag("NPC"))
        {
            other.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("NPC"))
        {
            if (Input.GetKey(KeyCode.E) && !EstaEnDialogo)
            {
                /*other.gameObject.GetComponent<DialogoCorrespondiente>().
                dialogoCorrespondiente.gameObject.SetActive(true);

                other.gameObject.GetComponent<DialogoCorrespondiente>().
                dialogoCorrespondiente.gameObject.transform.parent.gameObject.
                transform.GetComponent<DialogosLists>().activar = true;*/

                if (other.gameObject.name == "Alcalde")
                {
                    other.gameObject.GetComponent<DialogoCorrespondiente>().dialogoCorrespondiente.gameObject.SetActive(true);
                    canvasDialogos.GetComponent<DialoguesSystem>().activar = true;
                    TriggerAlcalde = true;

                    EstaEnDialogo = true;
                }

                if (other.gameObject.name == "Sergey")
                {
                    TriggerSergey = true;
                    other.gameObject.GetComponent<DialogoCorrespondiente>().dialogoCorrespondiente.gameObject.SetActive(true);
                    canvasDialogos.GetComponent<DialoguesSystem>().activar = true;

                    EstaEnDialogo = true;
                }

                if (other.gameObject.name == "Lulu")
                {
                    TriggerLulu = true;
                    other.gameObject.GetComponent<DialogoCorrespondiente>().dialogoCorrespondiente.gameObject.SetActive(true);
                    canvasDialogos.GetComponent<DialoguesSystem>().activar = true;

                    EstaEnDialogo = true;
                }

                if (other.gameObject.name == "Parsifal")
                {
                    TriggerParsifal = true;
                    other.gameObject.GetComponent<DialogoCorrespondiente>().dialogoCorrespondiente.gameObject.SetActive(true);
                    canvasDialogos.GetComponent<DialoguesSystem>().activar = true;

                    EstaEnDialogo = true;
                }

            }
        }

        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("NPC"))
        {

            canvasDialogos.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "";
            EstaEnDialogo = false;
            other.gameObject.GetComponent<DialogoCorrespondiente>().dialogoCorrespondiente.gameObject.SetActive(false);

            //maneja el cuadro de texto de interactuar

            other.gameObject.GetComponent<DialogoCorrespondiente>().
            dialogoCorrespondiente.gameObject.SetActive(false);

            other.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
