using System.Collections.Generic;
using UnityEngine;

public class Dialogos : MonoBehaviour
{

    public List<string> dialogos;

    public List<int> dialogosSeleccionados;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        this.gameObject.transform.parent.gameObject.GetComponent<DialogosLists>().dialogos = dialogos;

        this.gameObject.transform.parent.gameObject.GetComponent<DialogosLists>().dialogosSeleccionados = dialogosSeleccionados;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
