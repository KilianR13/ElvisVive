using UnityEngine;

public class EventsTriggeredByPlayer : MonoBehaviour
{

    public GameObject soundHandler;

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
    }
}
