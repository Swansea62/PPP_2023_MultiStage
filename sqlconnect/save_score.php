<?php

$con = mysqli_connect('multistagedb.db', 'ahughes', 'sX6VzxMtrg4*E', 'unityaccess');

// Get the score from the request parameters
$username = $_POST['username'];
$score = $_POST['score'];

// Check that connection happened
if (mysqli_connect_errno())
{
    echo "1: Connection failed"; //error code #1 = connection failed
    exit();
}

// Check if the new score is lower than the current score for the player
$sql = "SELECT score FROM players WHERE username = '$username'";
$result = mysqli_query($con, $sql);

if (mysqli_num_rows($result) > 0) {
  $row = mysqli_fetch_assoc($result);
  $currentScore = (float) $row['score'];
  
  if ($score < $currentScore) {
    // Update the score in the database
    $sql = "UPDATE players SET score = $score WHERE username = '$username'";
    $result = mysqli_query($con, $sql);

    if ($result) {
      if (mysqli_affected_rows($con) > 0) {
        echo "Score updated successfully";
      } else {
        echo "No matching record found for username $username";
      }
    } else {
      echo "Error updating score: " . mysqli_error($con);
    }
  } else {
    echo "New score is not lower than current score for username $username";
  }
} else {
  echo "No matching record found for username $username";
}

?>

