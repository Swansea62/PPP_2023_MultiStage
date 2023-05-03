// using UnityEngine;
// using UnityEngine.Networking;
// using System.Collections.Generic;

// public class ScoreController : MonoBehaviour
// {

//     public void SaveScore(float score)
//     {
//         //New dictionary to store the score data
//         Dictionary<string, string> formData = new Dictionary<string, string>();
//         formData.Add("score", score.ToString());

//         // UnitWebRequest with POST Method
//         UnityWebRequest request = UnityWebRequest.Post("http://localhost/save_score.php", formData);

//         // Send the request
//         request.SendWebRequest();

//         // Check if there was an error with the request
//         if (request.result != UnityWebRequest.Result.Success)
//         {
//             Debug.LogError(request.error);
//         }
//         else
//         {
//             Debug.Log(request.downloadHandler.text);
//         }
//     }
// }
