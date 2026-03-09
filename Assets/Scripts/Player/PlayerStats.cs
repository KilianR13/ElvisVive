using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [HideInInspector] // Esto solo oculta la variable "health" en el inspector. Más cómodo.
    public int health;
    [SerializeField] private int maxHealth; 

    public bool potenciado;

    public float TimerPotenciador;
    [SerializeField] PlayerHUDHandler PlayerHUD;

    public bool hasLeit;

    public bool hasDodec;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
        PlayerHUD.UpdateHealthbar(health, maxHealth);
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

    // Función a la que se llama cuando el jugador recibe daño. Actualiza automáticamente la barra de vida.
    public void TakeDamage(int damage)
    {
        if (health - damage <= 0)
        {
            PlayerHUD.PlayerHealthBar.value = 0;
            PlayerDie();
        }

        health -= damage;
        PlayerHUD.UpdateHealthbar(health, maxHealth);
        
    }

    // Placeholder
    public void PlayerDie()
    {
        
    }
}
