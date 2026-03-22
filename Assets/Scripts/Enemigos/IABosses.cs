using System.Collections;
using System.Numerics;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;

public class IABosses : MonoBehaviour
{
    [SerializeField] private GameObject player;

    public GameObject soundHandler;

    public bool cigala,fari;

    private bool activo; //secuencia cigala

    public float tiempoCooldownCigalaAsignado, tiempoCooldownFariAsignado, tiempoVulnerabilidadAsignado; 

    public float cooldownCigala, cooldownFari;

    [SerializeField] private float intensityVariation;

    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        animator = this.gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>();
        
       player = GameObject.Find("Player");

       soundHandler = GameObject.Find("SoundHandler");

       cooldownCigala = tiempoCooldownCigalaAsignado;

       cooldownFari = tiempoCooldownFariAsignado;
    }

    // Update is called once per frame
    void Update()
    {

        animator.SetFloat("Vida", this.gameObject.GetComponent<BossesStats>().vidas);

        animator.SetTrigger("Derrota");

        UnityEngine.Vector3 posicionJugador = new UnityEngine.Vector3 (player.transform.position.x, this.transform.position.y, player.transform.position.z); 

        if (this.gameObject.GetComponent<LanzarProyectil>().playerInRange)
        {
            this.gameObject.transform.LookAt(posicionJugador);
        }  

        intensityVariation = Mathf.PingPong(Time.time * 3, 1f);

        cooldownCigala -= Time.deltaTime;

        cooldownFari -= Time.deltaTime;

        if (this.gameObject.CompareTag("Paquirrin") && this.gameObject.GetComponent<BossesStats>().vidas <= 0)
        {
            StartCoroutine(SecuenciaFinalPaquirrin());
        }


        if (cigala)
        {
            CigalaIA();
        }

        if (fari)
        {
            FariIA();
        }
    }

    //a este punto se deberian tener el ataque principal y el de la dodecafonia

    private void CigalaIA()
    {

        if (this.gameObject.GetComponent<BossesStats>().confuso)
        {
            cooldownCigala = tiempoCooldownCigalaAsignado;

            StartCoroutine(DistortMusic());

            player.GetComponent<PlayerMovement>().lensDistortion.intensity.value = 0;
        }
        
        if (cooldownCigala < 0 && !activo && this.gameObject.GetComponent<LanzarProyectil>().playerInRange)
        {
            player.GetComponent<PlayerMovement>().lensDistortion.intensity.value = intensityVariation;

            if (cooldownCigala < -5)
            {
                cooldownCigala = tiempoCooldownCigalaAsignado;

                player.GetComponent<PlayerMovement>().lensDistortion.intensity.value = 0.4f;
            }
        }

        if (this.gameObject.GetComponent<BossesStats>().vidas <= 0 && !activo)
        {

            activo = true;

            StartCoroutine(SecuenciaFinalCigala());
        }
    }

    IEnumerator DistortMusic()
    {
        for(int i = 0; i < 50; i++)
        {
            soundHandler.GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1.2f);

            yield return new WaitForSeconds(0.05f);
        }

        soundHandler.GetComponent<AudioSource>().pitch = 1;
    }

    IEnumerator SecuenciaFinalPaquirrin()
    {
        //soundHandler.GetComponent<AudioSource>().loop = false;

        yield return new WaitForSeconds(0.5f);

        soundHandler.GetComponent<AudioSource>().clip = soundHandler.GetComponent<AlmacenamientoSonidos>().sonidosPaquirrín[1];

        soundHandler.GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(2);

        player.GetComponent<PlayerStats>().health = 12;

        this.gameObject.SetActive(false);
    }

    IEnumerator SecuenciaFinalCigala()
    {

        //soundHandler.GetComponent<AudioSource>().loop = false;

        soundHandler.GetComponent<AudioSource>().clip = soundHandler.GetComponent<AlmacenamientoSonidos>().sonidosCigala[1];

        soundHandler.GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(10);

        player.GetComponent<PlayerStats>().health = 12;

        this.gameObject.SetActive(false);
    }

    private void FariIA()
    {
        if (this.gameObject.GetComponent<BossesStats>().confuso)
        {
            cooldownCigala = tiempoCooldownCigalaAsignado;

            StartCoroutine(DistortMusic());

            player.GetComponent<PlayerMovement>().lensDistortion.intensity.value = 0;
        }

         if (this.gameObject.GetComponent<BossesStats>().vidas <= 0 && !activo)
        {
            activo = true;

            StartCoroutine(SecuenciaFinalFari());
        }
    }

    private IEnumerator SecuenciaFinalFari()
    {
       soundHandler.GetComponent<AudioSource>().clip = soundHandler.GetComponent<AlmacenamientoSonidos>().sonidosFari[1];

        soundHandler.GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(2);

        player.GetComponent<PlayerStats>().health = 12;

        this.gameObject.SetActive(false);
    }
}
