using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject credits;

    public void StartGame()
    {
        SceneManager.LoadScene("Abyss");
    }

    public void ShowCredits()
    {
        credits.SetActive(true);
    }

    public void CloseCredits()
    {
        credits.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
