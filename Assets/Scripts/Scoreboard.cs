// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.Networking;
// using TMPro;

// public class Scoreboard : MonoBehaviour
// {
//     public TextMeshProUGUI firstPlaceTimeText;
//     public TextMeshProUGUI secondPlaceTimeText;
//     public TextMeshProUGUI thirdPlaceTimeText;

//     public TextMeshProUGUI firstPlaceUserText;
//     public TextMeshProUGUI secondPlaceUserText;
//     public TextMeshProUGUI thirdPlaceUserText;

//     private Dictionary<float, string> lowestScores = new Dictionary<float, string>();

//     private void Start()
//     {
//         StartCoroutine(GetScores());
//     }

//     // Gets the scores from the scoreboard.php script and update the assigned text fields in the scene
//     private IEnumerator GetScores()
//     {
//         using (UnityWebRequest www = UnityWebRequest.Get("http://localhost/sqlconnect/scoreboard.php"))
//         {
//             yield return www.SendWebRequest();

//             if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
//             {
//                 Debug.LogError(www.error);
//             }
//             else
//             {
//                 string[] scoreData = www.downloadHandler.text.Split(',');

//                 if (scoreData.Length >= 6)
//                 {
//                     firstPlaceTimeText.text = scoreData[0];
//                     firstPlaceUserText.text = scoreData[1];

//                     secondPlaceTimeText.text = scoreData[2];
//                     secondPlaceUserText.text = scoreData[3];

//                     thirdPlaceTimeText.text = scoreData[4];
//                     thirdPlaceUserText.text = scoreData[5];
//                 }
//             }
//         }
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    public TextMeshProUGUI firstPlaceTimeText;
    public TextMeshProUGUI secondPlaceTimeText;
    public TextMeshProUGUI thirdPlaceTimeText;

    public TextMeshProUGUI firstPlaceUserText;
    public TextMeshProUGUI secondPlaceUserText;
    public TextMeshProUGUI thirdPlaceUserText;

    private Dictionary<float, string> lowestScores = new Dictionary<float, string>();

    private void Start()
    {
        StartCoroutine(GetScores());
    }

    // Gets the scores from the scoreboard.php script and update the assigned text fields in the scene
    private IEnumerator GetScores()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("https://multistage.nfshost.com/sqlconnect/scoreboard.php"))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError(www.error);
            }
            else
            {
                string[] scoreData = www.downloadHandler.text.Split(',');

                if (scoreData.Length >= 6)
                {
                    // Add the scores to the dictionary
                    lowestScores.Add(float.Parse(scoreData[0]), scoreData[1]);
                    lowestScores.Add(float.Parse(scoreData[2]), scoreData[3]);
                    lowestScores.Add(float.Parse(scoreData[4]), scoreData[5]);

                    // Sort the dictionary by key (score) in ascending order
                    List<float> scoreList = new List<float>(lowestScores.Keys);
                    scoreList.Sort();

                    // Assign the scores to the text fields in the correct order
                    firstPlaceTimeText.text = scoreList[0].ToString();
                    firstPlaceUserText.text = lowestScores[scoreList[0]];

                    secondPlaceTimeText.text = scoreList[1].ToString();
                    secondPlaceUserText.text = lowestScores[scoreList[1]];

                    thirdPlaceTimeText.text = scoreList[2].ToString();
                    thirdPlaceUserText.text = lowestScores[scoreList[2]];
                }
            }
        }
    }
}



