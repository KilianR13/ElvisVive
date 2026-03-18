using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;

public class DialoguesSystem : MonoBehaviour
{
    public static DialoguesSystem instance;

    [Header ("Dialogos y cuales son los elegidos")]
    public List<string> dialogos;

    [SerializeField] private List<string> dialogosTemp;

    public List<int> dialogosSeleccionados;

    [Header ("En el caso de que los dialogos vengan desordenados")]

    public bool ordenar;

    [Header ("Modificadores de los dialogos")]

    [Range(0.01f, 2)]

    public float printSpeedMultipler;

    public float delayEntreDialogos;

    [Header ("Variables de control")]

    [SerializeField] private string AppendToString;

    public List<char[]> dialoguesToChar;

    private float delayForLetters;

    [Header ("Activadores")]
    public bool activar;

    [Header ("Donde poner el texto")]

    public TextMeshProUGUI cajaDeTexto;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

        dialogosTemp = dialogos;

        if (ordenar)
        {
            OrderDialogues();

            ordenar = !ordenar;
        }

        if (activar)
        {
            DialoguesToChar();

            PrintAll();
        }
    }

    private void OrderDialogues()
    {
        for (int i = 0; i < dialogosSeleccionados.Count; i++)
        {
            int espacio = dialogosSeleccionados[i];

            dialogos[i] = dialogosTemp[espacio];
        }
    }

    //pasa todos los dialogos a una lista de arrays de chars

    private void DialoguesToChar()
    {

        dialoguesToChar = new List<char[]>();

        for (int i = 0; i < dialogos.Count; i++)
        {
            
            char[] dialogosCharArray = dialogos[i].ToCharArray();

            Debug.Log($"{new string(dialogosCharArray)}");

            dialoguesToChar[i] = dialogosCharArray;
        }
    }

    private async void PrintAll()
    {
        //recorriendo la lista de dialogos (General List -> lists)

        for (int i = 0; i < dialogos.Count; i++)
        {
            //recorriendo las listas, dentro de las listas aqui se obtienen todos los dialogos a arrays de chars

            //lists -> char arrays in lists
            for(int j = 0; j < dialoguesToChar[i].Length; j++)
            {
                PrintDialogue(dialoguesToChar[j]);

                await UniTask.WaitForSeconds(delayForLetters + delayEntreDialogos);

                cajaDeTexto.text = "";
            }
        }
    }

    private async void PrintDialogue(char[] dialogo)
    {
        for(int i = 0; i < dialogo.Length; i++)
        {
            char letra = dialogo[i];

            WordPrintDelay(letra);

            cajaDeTexto.text += letra; 
        }
    }

    //hace la suma total de delay para sumarlo para la duracion del dialogo

    private float WordPrintDelay(char letra)
    {

        float delay;

        switch (letra)
        {
            case ',':

                delayForLetters += 0.5f;
                delay = 0.5f;

                break;

            case '.':

                delayForLetters += 0.8f;
                delay = 0.8f;

                break;
                
            default:

                delayForLetters += 0.2f;
                delay = 0.2f;

                break;
        }

        return delay;


            /*delayForLetters += arrayChar[i] switch
            {
                ',' => 0.5f,
                '.' => 0.8f,
                _ => 0.2f,
            };*/
    }
}
