using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;

public class StopwatchController : MonoBehaviour
{
    public Text timerText;
    public GameObject endGoal;
    private float startTime;
    private bool isRunning;
    public TextMeshProUGUI CompletedTimeText;

    private void Start()
    {
        startTime = Time.time;
        isRunning = true;
    }

    private void Update()
    {
        if (isRunning)
        {
            float currentTime = Time.time - startTime;

            string minutes = ((int)currentTime / 60).ToString("00");
            string seconds = (currentTime % 60).ToString("00");
            string milliseconds = ((int)(currentTime * 100f) % 100).ToString("00");

            timerText.text = minutes + ":" + seconds + "." + milliseconds;
        }
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "EndGoal" && isRunning)
        {
            isRunning = false;
            float timeTaken = Time.time - startTime;
            Debug.Log("Level completed in " + timeTaken + " seconds");
            SendScore(timeTaken);
            CompletedTimeText.text = timeTaken.ToString();
        }

    }

   private void SendScore(float score)
    {
    // Instead of using MultiPartForm, decided to try out Dictionary for storing form data
    Dictionary<string, string> formData = new Dictionary<string, string>();
    formData.Add("score", score.ToString());

    // Gets the username of the logged-in player and include it in the POST data
    if (DBManager.username != null)
    {
        formData.Add("username", DBManager.username);
    }

    // Made a new request and specificed the method as a POST
    UnityWebRequest request = UnityWebRequest.Post("https://multistage.nfshost.com/sqlconnect/save_score.php", formData);
    request.SendWebRequest();

    // Checking if there was an error with the request
    if (request.result != UnityWebRequest.Result.Success)
     {
           Debug.LogError(request.error);
        }
     else
        {
           Debug.Log(request.downloadHandler.text);
        }
    }

}




