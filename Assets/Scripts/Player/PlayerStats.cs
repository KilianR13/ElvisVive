using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public int health;

    public bool potenciado;

    public float TimerPotenciador;

    private float healthImageXOffset;

    private float healthImageYOffset;

    [SerializeField] GameObject lifePrefab;

    [SerializeField] GameObject lifesSpawn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(GenerateLives());
    }

    // Update is called once per frame
    void Update()
    {

        if(TimerPotenciador > 0)
        {
            potenciado = true;
        }
        else
        {
            potenciado = false;
        }

        TimerPotenciador -= Time.deltaTime;



    }

    IEnumerator GenerateLives()
    {

        for (int i = 1; i < health + 1; i++)
        {
            
            Instantiate(lifePrefab, lifesSpawn.transform.position - new Vector3(healthImageXOffset, healthImageYOffset, 0), quaternion.identity, lifesSpawn.transform);

            healthImageXOffset += 120;

            if (i % 6 == 0)
            {
                healthImageYOffset += 120;

                healthImageXOffset = 0; 
            }

            yield return null;

        }

        yield return new WaitForSeconds(0.001f);
    }
}
