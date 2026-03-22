using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUDHandler : MonoBehaviour
{
    public Slider PlayerHealthBar;
    public TextMeshProUGUI currentHealth;

    public GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = this.gameObject.transform.parent.gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"Valor de la barra de vida: {PlayerHealthBar.value}");
        PlayerHealthBar.value = (float)player.gameObject.GetComponent<PlayerStats>().health / (float)player.gameObject.GetComponent<PlayerStats>().maxHealth;
        currentHealth.text = $"{player.GetComponent<PlayerStats>().health}/{player.GetComponent<PlayerStats>().maxHealth}";
    }

    public void UpdateHealthbar(float currentValue, float maxValue)
    {
        
    }
}
