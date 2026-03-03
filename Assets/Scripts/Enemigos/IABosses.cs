using UnityEngine;

public class IABosses : MonoBehaviour
{

    [SerializeField] private int numeroBoss;

    [SerializeField] private GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        switch (numeroBoss)
        {

            case 1:

                Boss1IA();

                break;
            
            default:

                //no hay ese era el ultimo

                break;
        }
    }

    private void Boss1IA()
    {
        
    }
}
