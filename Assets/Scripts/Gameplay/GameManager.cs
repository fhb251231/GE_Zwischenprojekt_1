using System;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

   [SerializeField] private InputActionReference pause;
   [SerializeField] private GameObject pauseMenu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;

        if (pauseMenu != null)
            pauseMenu.SetActive(true);
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
}


