using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGoal : MonoBehaviour
{
    void OnTriggerEnter()
    {
        Loader.Load(Loader.Scene.LevelCompleteScreen);
    }
}
