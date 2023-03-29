using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    // private GameMaster gm;
    public GameObject gameOverMenu;
    public bool isOver;

    void Start()
    {
        gameOverMenu.SetActive(false);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "PitFloor")
        {
            isOver = true;
        }
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

    public void RestartGame()
    {
        Time.timeScale = 1f;
        Loader.Load(Loader.Scene.MultiStage_Level_1);
        transform.position = GameMaster.RestartCheckpointPos();
        isOver = false;
    }

    public void RestartFromCheckpoint()
    {
        Time.timeScale = 1f;
        Loader.Load(Loader.Scene.MultiStage_Level_1);
        transform.position = GameMaster.GetCheckpointPos();
        isOver = false;
    }
}
