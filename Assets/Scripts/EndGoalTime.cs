// using UnityEngine;
// using UnityEngine.UI;

// public class EndGoalTime : MonoBehaviour
// {
//     public Text scoreText;  // Text object that will display the score

//     private float startTime;  // Time when the game started
//     private float endTime;  // Time when the end goal was reached
//     private bool goalReached;  // Flag to track whether the end goal was reached

//     private void Start()
//     {
//         startTime = Time.time;  // Store the start time
//         goalReached = false;  // Initialize goalReached to false
//     }

//     private void OnTriggerEnter(Collider other)
//     {
//         if (other.CompareTag("Player") && !goalReached)
//         {
//             endTime = Time.time;  // Store the end time
//             float elapsedTime = endTime - startTime;  // Calculate the elapsed time
//             scoreText.text = "Score: " + elapsedTime.ToString("F2");  // Display the score with 2 decimal places
//             goalReached = true;  // Set goalReached to true to prevent multiple updates
//         }
//     }
// }

