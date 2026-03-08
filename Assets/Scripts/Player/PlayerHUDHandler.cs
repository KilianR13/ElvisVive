using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUDHandler : MonoBehaviour
{
    public Slider PlayerHealthBar;
    public TextMeshProUGUI currentHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealthbar(float currentValue, float maxValue)
    {
        Debug.Log($"Valor de la barra de vida: {PlayerHealthBar.value}");
        PlayerHealthBar.value = currentValue / maxValue;
        currentHealth.text = $"{currentValue}/{maxValue}";
    }
}
