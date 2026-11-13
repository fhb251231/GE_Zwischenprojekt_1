using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_Over_Scripts : MonoBehaviour
{
    public void Setup()
    {
        gameObject.SetActive(true);
    }

    public void RestartButton()
    {
    SceneManager.LoadScene("AI Behavior");    
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
