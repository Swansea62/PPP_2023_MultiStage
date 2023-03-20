using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{
    public enum Scene {
        MainMenuScreen,
        RegisterMenu,
        LoginMenu,
        MultiStage_Level_1,
        GameOverScreen,
        OptionsScreen,
        Scoreboard,
        Controls
    }


    public static void Load(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }
}
