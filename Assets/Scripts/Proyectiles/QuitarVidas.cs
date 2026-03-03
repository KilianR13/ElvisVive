using UnityEngine;

public class QuitarVidas : MonoBehaviour
{

    [SerializeField] private GameObject UI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UI = GameObject.Find("UI");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerStats>().health--;

            int childCount = UI.transform.GetChild(0).gameObject.transform.childCount - 1;

            Destroy(UI.transform.GetChild(0).GetChild(childCount).gameObject);

            Destroy(this.gameObject);
        }
    }
}
