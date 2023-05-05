using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;

public class GetPlayerScore : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public void Start()
    {
        StartCoroutine(GetPlayerScoreFromDB());
    }

    IEnumerator GetPlayerScoreFromDB()
{
    string username = DBManager.username;

    // Creating a form to send the POST request to my php script (Outdated WWWForm has to be used for this interaction)
    WWWForm form = new WWWForm();
    form.AddField("username", username);

    // Sending the POST request to the php script and wait for a response
    UnityWebRequest www = UnityWebRequest.Post("https://multistage.nfshost.com/sqlconnect/get_score.php", form);
    yield return www.SendWebRequest();

    // Checking for errors
    if (www.result != UnityWebRequest.Result.Success)
    {
        Debug.LogError(www.error);
    }
    else
    {
        // Getting the score from the response and display it in the scoreText object
        string score = www.downloadHandler.text;
        scoreText.text = score;
    }
}



}


