using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Panels")]
    public GameObject optionsPanel;
    public void PlayGame()
    {
        SceneManager.LoadScene("SERGI_TEST");
    }
    public void OpenOptions()
    {
        optionsPanel.SetActive(true);
    }
    public void CloseOptions()
    {
        optionsPanel.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Se cierra el juego");
    }
}
