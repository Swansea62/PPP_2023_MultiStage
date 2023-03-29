using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleteMenu : MonoBehaviour
{
    public GameObject levelCompleteMenu;

    public bool isComplete;

    void Start()
    {
        levelCompleteMenu.SetActive(false);
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "EndGoal")
        {
            Debug.Log("Level is complete");
            isComplete = true;
        }
    }

    void Update()
    {
        if (isComplete)
        {
            Time.timeScale = 0f;
            levelCompleteMenu.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        Loader.Load(Loader.Scene.MultiStage_Level_1);
        transform.position = GameMaster.RestartCheckpointPos();
        isComplete = false;
    }
}
