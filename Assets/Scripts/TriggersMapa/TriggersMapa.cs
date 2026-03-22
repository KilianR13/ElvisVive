using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggersMapa : MonoBehaviour
{

    public GameObject Paquirrin;

    public GameObject Cigala;

    public GameObject Fari;

    public GameObject textoCelda;

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
        
    }

    void OnTriggerStay(Collider other)
    {
        if (Paquirrin.GetComponent<BossesStats>().vidas <= 0 &&
            Cigala.GetComponent<BossesStats>().vidas <= 0 &&
            Fari.GetComponent<BossesStats>().vidas <= 0 && other.gameObject.CompareTag("Player"))
        {

        SceneManager.LoadScene(3);

        }
        else
        {
            textoCelda.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        textoCelda.gameObject.SetActive(false);
    }
}
