using UnityEngine;
using UnityEngine.SceneManagement;
public class Main_Menu_Script : MonoBehaviour
{
    public void Setup()
    {
        gameObject.SetActive(true);
    }

    public void StartButton()
    {
    SceneManager.LoadScene("Level");    
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
