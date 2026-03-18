using System.Collections.Generic;
using UnityEngine;

public class Dialogos : MonoBehaviour
{

    public List<string> dialogos;

    public List<int> dialogosSeleccionados;

    public string fullDialogue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ConvertToFullDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private async void ConvertToFullDialogue()
    {
        for(int i = 0; i < dialogos.Count; i++)
        {
            fullDialogue += dialogos[i];
        }
    }
}
