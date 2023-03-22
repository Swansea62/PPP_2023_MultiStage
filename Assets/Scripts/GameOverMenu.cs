using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverMenu;
    public bool isOver;
    public bool isPaused;

    void Start()
    {
        gameOverMenu.SetActive(false);
    }

    void Update()
    {
        if (isOver)
        {
            Time.timeScale = 0f;
            gameOverMenu.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "PitFloor")
        {
            isOver = true;
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        Loader.Load(Loader.Scene.MultiStage_Level_1);
        isPaused = false;
        isOver = false;
    }
}
