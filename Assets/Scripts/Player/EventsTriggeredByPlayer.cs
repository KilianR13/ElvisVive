using UnityEngine;

public class EventsTriggeredByPlayer : MonoBehaviour
{

    public GameObject soundHandler;

    public bool TriggerAlcalde, TriggerSergey, TriggerLulu, TriggerParsifal;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        soundHandler = GameObject.Find("SoundHandler");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
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
            if (Input.GetKey(KeyCode.E))
            {
                other.gameObject.GetComponent<DialogoCorrespondiente>().
                dialogoCorrespondiente.gameObject.SetActive(true);

                other.gameObject.GetComponent<DialogoCorrespondiente>().
                dialogoCorrespondiente.gameObject.transform.parent.gameObject.
                transform.GetComponent<DialogosLists>().activar = true;

                if (other.gameObject.name == "Alcalde")
                {
                    TriggerAlcalde = true;
                }

                if (other.gameObject.name == "Sergey")
                {
                    TriggerSergey = true;
                }

                if (other.gameObject.name == "Lulu")
                {
                    TriggerLulu = true;
                }

                if (other.gameObject.name == "Parsifal")
                {
                    TriggerParsifal = true;
                }

            }
        }

        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("NPC"))
        {
            other.gameObject.GetComponent<DialogoCorrespondiente>().
            dialogoCorrespondiente.gameObject.SetActive(false);

            other.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
