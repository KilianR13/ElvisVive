using UnityEngine;

public class BossesStats : MonoBehaviour
{

    public int vidas;

    public bool confuso;

    [SerializeField] private float TimerConfuso;

    public float TimerConfusoAsignado;

    public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

        if(TimerConfuso > -0.1f)
        TimerConfuso -= Time.deltaTime;

        if(TimerConfuso > 0)
        {
            confuso = true;
        }
        else
        {
            confuso = false;
        }

    }

    void OnTriggerEnter(Collider other)
    {

        Debug.Log("TriggerEnter Boss");

        if(other.gameObject.CompareTag("Onda"))
        {

            if (other.gameObject.GetComponent<AttackType>().leifmotif)
            {
                player.GetComponent<PlayerStats>().TimerPotenciador = 5;
            }

            if (other.gameObject.GetComponent<AttackType>().dodecafonico)
            {
                TimerConfuso = TimerConfusoAsignado;
            }


            Debug.Log("Daño a jefe");

            if(this.gameObject.GetComponent<IABosses>().cooldownFari <= 0 && this.gameObject.GetComponent<IABosses>().fari)
            {

                Debug.Log("entrada ataque fari");

                if (other.gameObject.GetComponent<AttackType>().dodecafonico || confuso)
                {
                    vidas--;

                    this.gameObject.GetComponent<IABosses>().cooldownFari = this.gameObject.GetComponent<IABosses>().tiempoCooldownFariAsignado;

                    Destroy(other.gameObject);
                }
                else
                {
                    other.gameObject.transform.Rotate(0,0,180);
                }
            }
            else
            {
               vidas--; 

               Destroy(other.gameObject);
            }
        }
    }
}
