using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    [Header("Menu Screens")]
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject optionsMenu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainMenu.SetActive(true);
        loadingScreen.SetActive(false);
        optionsMenu.SetActive(false);
    }

    public void QuitGame()
    {
        // Directiva de preprocesador
        #if UNITY_EDITOR
            // Si estamos en el editor de Unity, usamos el comando para detener el juego.
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            // Si estamos en un ejecutable (Build), cerramos la aplicación.
            Application.Quit();
        #endif
    }
}
