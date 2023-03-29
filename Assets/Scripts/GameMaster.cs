using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameMaster : MonoBehaviour
{
    private static GameMaster instance;
    private static Vector3 originalPos = new Vector3(0, 1.5f, -10);
    private static Vector3 lastCheckpointPos = originalPos;

    //private static float currentTime = Stopwatch.GetComponent<Stopwatch>();

    // void Awake()
    // {
    //     if (instance == null)
    //     {
            
    //         instance = this;
    //         DontDestroyOnLoad(instance);
    //     }
    //     else
    //     {
    //         Destroy(gameObject);
    //     }
    // }

    public static Vector3 RestartCheckpointPos(){
        lastCheckpointPos = originalPos;
        return lastCheckpointPos;
    }

    public static Vector3 GetCheckpointPos(){
        Debug.Log("GetCheckpointPos: " + lastCheckpointPos);
        return lastCheckpointPos;
    }

    public static void SetCheckpointPos(Vector3 pos){
        Debug.Log("SetCheckpointPos: " + pos);
        //SetTime(currentTime);
        lastCheckpointPos = pos;
    }

    public static Vector3 GetOriginalPos(){
        Debug.Log("GetOriginalPos: " + originalPos);
        return originalPos;
    }

    public static void SetOriginalPos(Vector3 pos){
        Debug.Log("SetOriginalPos: " + pos);
        originalPos = pos;
    }

    /*public static void SetTime(float time)
    {
        Debug.Log("Time: " + time);
        currentTime = time;
    }

    public static float GetTime()
    {
        Debug.Log("Time set: " + currentTime);
        return currentTime;
    }*/
}
