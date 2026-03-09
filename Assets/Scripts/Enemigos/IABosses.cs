using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class IABosses : MonoBehaviour
{

    [SerializeField] private GameObject player;

    public bool cigala,fari;

    public float tiempoCooldownCigalaAsignado, tiempoCooldownFariAsignado, tiempoVulnerabilidadAsignado; 

    [SerializeField] private float cooldownCigala, cooldownFari;

    [SerializeField] private float intensityVariation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       player = GameObject.Find("Player");

       cooldownCigala = tiempoCooldownCigalaAsignado;

       cooldownFari = tiempoCooldownFariAsignado;
    }

    // Update is called once per frame
    void Update()
    {

        intensityVariation = Mathf.PingPong(Time.time * 3, 1f);

        cooldownCigala -= Time.deltaTime;

        cooldownFari -= Time.deltaTime;


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

                player.GetComponent<PlayerMovement>().lensDistortion.intensity.value = 0;
            }
        
        if (cooldownCigala < 0)
        {
            player.GetComponent<PlayerMovement>().lensDistortion.intensity.value = intensityVariation;

            if (cooldownCigala < -5)
            {
                cooldownCigala = tiempoCooldownCigalaAsignado;

                player.GetComponent<PlayerMovement>().lensDistortion.intensity.value = 0.4f;
            }
        }
    }

    private void FariIA()
    {
        if (cooldownFari < 0)
        {
            
        }
    }

    private void EndOfHability()
    {
        
    }
}
