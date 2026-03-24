using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScreenButtons : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
    }

    public void ReStart()
    {
        SceneManager.LoadScene(1);
    }
}
