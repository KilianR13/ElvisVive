using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AlmacenamientoSonidos : MonoBehaviour
{

    [Header ("aqui se ponen MP3 directamente")]

    public List<AudioClip> sonidosJugador;
    public List<AudioClip> sonidosPaquirrín;
    public List<AudioClip> sonidosCigala;
    public List<AudioClip> sonidosFari;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //StartCoroutine(Reproducir());
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.GetComponent<AudioSource>().clip == sonidosPaquirrín[0] ||
            this.gameObject.GetComponent<AudioSource>().clip == sonidosCigala[0] ||
            this.gameObject.GetComponent<AudioSource>().clip == sonidosFari[0])
        {
            this.gameObject.GetComponent<AudioSource>().loop = true;
        }

        else
        {
            this.gameObject.GetComponent<AudioSource>().loop = false;
        }
    }



    //test

    IEnumerator Reproducir()
    {
        while (true)
        {
            this.gameObject.GetComponent<AudioSource>().Play();

            yield return new WaitForSeconds(0.5f);
        }
    }
}
