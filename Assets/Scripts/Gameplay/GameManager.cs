using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{

   [SerializeField] private InputActionReference pause;

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
        pause.action.performed += HandlePauseButtonPressed;
        pause.action.Disable();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void RestartGame()
    {
        
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


