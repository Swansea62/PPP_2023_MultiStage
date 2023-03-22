using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPaused;
    public bool isOver;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "PitFloor")
        {
            isOver = true;
            pauseMenu.SetActive(false);
            isPaused = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
        else
        {
            if (isOver)
            {
                isPaused = false;
                pauseMenu.SetActive(false);
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        Cursor.visible = false;
        isPaused = false;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        Loader.Load(Loader.Scene.MultiStage_Level_1);
        isPaused = false;
    }

    public void ToMainMenu()
    {
        Time.timeScale = 1f;
        Loader.Load(Loader.Scene.MainMenuScreen);
        isPaused = false;
    }

    public void ToOptions()
    {
        Time.timeScale = 1f;
        Loader.Load(Loader.Scene.OptionsScreen);
    }
}
