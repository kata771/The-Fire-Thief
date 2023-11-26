using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager UI; 
    public GameObject pauseUI;
    private bool isGamePaused;

    private void Awake()
    {
        if (UI == null){
            UI = this;
        }
        else{
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ResumeGame();
    }

    ///<summary>
    /// Method checks if ESC is pressed and pauses the game in case of true.
    ///</summary>
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseGame();
        }
    }

    ///Depending on the state of the game when the "esc" key is pressed, the method resumes or pauses the game
    public void TogglePauseGame()
    {
        if (isGamePaused){
            ResumeGame();
        }
        else{
            PauseGame();
        }
    }

    /// Method pauses the game by setting pauseUI canvas to true and stops the time.
    public void PauseGame()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f; 
        isGamePaused = true;
    }

    /// Method resumes the game by disabling pauseUI canvas GameObject and ufreezes the time.
    ///
    public void ResumeGame()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f; 
        isGamePaused = false;
    }
}
