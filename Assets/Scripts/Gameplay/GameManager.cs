using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

   [SerializeField] private InputActionReference pause;

   [SerializeField] private GameObject pauseMenu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        Time.timeScale = 1;

        if (pauseMenu != null)
            pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        pause.action.Enable();
        
        pause.action.performed += HandlePauseButtonPressed;

    }

    private void OnDisable()
    {
        pause.action.performed -= HandlePauseButtonPressed;

        pause.action.Disable();

    }

    public void PauseGame()
    {
        Time.timeScale = 0;

        if (pauseMenu != null)
            pauseMenu.SetActive(true);

        // Maus entsperren und sichtbar machen
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;

        if (pauseMenu != null)
            pauseMenu.SetActive(false);

        //Maus wieder sperren und verstecken
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }

    public void QuitGame()
    {
        Application.Quit();

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    private void HandlePauseButtonPressed(InputAction.CallbackContext context)
    {
        if (Time.timeScale == 0)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    private void HandleRestartButtonPressed(InputAction.CallbackContext context)
    {
        RestartGame();
    }

    private void HandleQuitButtonPressed(InputAction.CallbackContext context)
    {
        QuitGame();
    }
}


