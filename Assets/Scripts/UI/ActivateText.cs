using Unity.VisualScripting;
using UnityEngine;

public class ActivateText : MonoBehaviour
{

    public GameObject leit;

    public GameObject dodec;

    public GameObject player;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = this.gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerAttack>().cooldownDodecafonia <= 0 & player.GetComponent<PlayerStats>().hasDodec)
        {
            dodec.gameObject.SetActive(true);
        }
        else
        {
           dodec.gameObject.SetActive(false); 
        }

        if (player.GetComponent<PlayerAttack>().cooldownLeitmotif <= 0 & player.GetComponent<PlayerStats>().hasLeit)
        {
            leit.gameObject.SetActive(true);
        }
        else
        {
           leit.gameObject.SetActive(false); 
        }
    }
}
