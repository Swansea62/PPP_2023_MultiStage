// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using UnityEngine.Networking;
// using TMPro;

// public class GetPlayerScore : MonoBehaviour
// {
//     public TextMeshProUGUI scoreText;

//     public void Start()
//     {
//         StartCoroutine(GetPlayerScoreFromDB());
//     }

//     IEnumerator GetPlayerScoreFromDB()
//     {
//         string username = DBManager.username;

//         // Send the request to the PHP script and wait for a response
//         UnityWebRequest www = UnityWebRequest.Get($"http://localhost/sqlconnect/get_score.php?username={username}");
//         yield return www.SendWebRequest();

//         // Check for errors
//         if (www.result != UnityWebRequest.Result.Success)
//         {
//             Debug.LogError(www.error);
//         }
//         else
//         {
//             // Get the score from the response and display it in the scoreText object
//             string score = www.downloadHandler.text;
//             scoreText.text = "Score: " + score;
//         }
//     }
// }

