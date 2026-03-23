using System.Collections.Generic;
using UnityEngine;

public class Dialogos : MonoBehaviour
{

    public List<string> dialogos;

    public List<int> dialogosSeleccionados;

    public string fullDialogue;

    public GameObject canvasDialogos;

    public bool alreadyTransfered, cancelDialogue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canvasDialogos = GameObject.Find("CanvasDialogos");

        ConvertToFullDialogue();
    }

    // Update is called once per frame
    void OnEnable()
    {   if (!alreadyTransfered)
        {
            canvasDialogos.GetComponent<DialoguesSystem>().dialogos = dialogos;

            canvasDialogos.GetComponent<DialoguesSystem>().dialogosSeleccionados = dialogosSeleccionados;

            cancelDialogue = false;

            alreadyTransfered = true;
        }
    }

    void OnDisable()
    {
        canvasDialogos.GetComponent<DialoguesSystem>().dialogos = new List<string>{""};

        canvasDialogos.GetComponent<DialoguesSystem>().dialogosSeleccionados = new List<int>{0};

        cancelDialogue = true;

        alreadyTransfered = false;
    }

    private async void ConvertToFullDialogue()
    {
        for(int i = 0; i < dialogos.Count; i++)
        {
            fullDialogue += dialogos[i];
        }
    }
}
