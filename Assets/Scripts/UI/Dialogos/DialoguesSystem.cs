using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
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

    [Range(0.01f, 5)]

    public float printSpeedMultipler;

    public float delayEntreDialogos;

    [Header ("Variables de control")]
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
        if (ordenar)
        {
            OrderDialogues();

            ordenar = !ordenar;
        }

        if (activar)
        {
            PrintAll();

            activar = !activar;
        }
    }

    private void OrderDialogues()
    {
        for (int j = 0; j < dialogosSeleccionados.Count; j++)
        {
            dialogosTemp.Add(dialogos[j]);
        }

        for(int i = 0; i < dialogosSeleccionados.Count; i++)
        {
            dialogos[i] = dialogosTemp[dialogosSeleccionados[i]];
        }
    }

    private async UniTask PrintDialogue(char[] dialogo)
    {
        for(int k = 0; k < dialogo.Length; k++)
        {
            Debug.LogWarning($"array dialogo: {dialogo[k]}");

            await UniTask.Delay(TimeSpan.FromSeconds(WordPrintDelay(dialogo[k])));

            cajaDeTexto.text += dialogo[k].ToString();
        }
    }

    //hace la suma total de delay para sumarlo para la duracion del dialogo

    private float WordPrintDelay(char letra)
    {

        float delay;

        switch (letra)
        {
            case ',':

                delayForLetters += 0.125f / printSpeedMultipler;
                delay = 0.125f / printSpeedMultipler;

                break;

            case '.':

                delayForLetters += 0.2f / printSpeedMultipler;
                delay = 0.2f / printSpeedMultipler;

                break;
                
            default:

                delayForLetters += 0.05f / printSpeedMultipler;
                delay = 0.05f / printSpeedMultipler;

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

    private async UniTaskVoid PrintAll()
    {

        if(dialogos != null) 
        {

            for (int i = 0; i < dialogos.Count; i++) //si se quiere interrumpir el dialogo, esto va a dar un error, no deberia interferir en el juego
            {
                foreach (char c in dialogos[i])
                {
                await UniTask.Delay(TimeSpan.FromSeconds(WordPrintDelay(c)));

                cajaDeTexto.text += c.ToString();
                }

            await UniTask.Delay(TimeSpan.FromSeconds(delayForLetters / printSpeedMultipler + delayEntreDialogos));

            cajaDeTexto.text = "";
            }
        }
        else
        {
            return;
        }    
        
    }
}
