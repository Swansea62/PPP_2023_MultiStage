<?php

$con = mysqli_connect('multistagedb.db', 'ahughes', 'sX6VzxMtrg4*E', 'unityaccess');

// Check that connection happened
if (mysqli_connect_errno())
{
    echo "1: Connection failed"; //error code #1 = connection failed
    exit();
}

// Retrieve the 3 lowest scores and relative usernames from the players table
$sql = "SELECT username, score FROM players ORDER BY score ASC LIMIT 3";
$result = mysqli_query($con, $sql);

// Initialize variables to hold the scores and usernames as strings otherwise I'd have to use json
$firstScore = "";
$firstUsername = "";
$secondScore = "";
$secondUsername = "";
$thirdScore = "";
$thirdUsername = "";

// Loop through the results and assign the scores and usernames to the appropriate variables
$i = 0;
while ($row = mysqli_fetch_assoc($result)) {
    if ($i == 0) {
        $firstScore = strval($row['score']);
        $firstUsername = $row['username'];
    }
    else if ($i == 1) {
        $secondScore = strval($row['score']);
        $secondUsername = $row['username'];
    }
    else if ($i == 2) {
        $thirdScore = strval($row['score']);
        $thirdUsername = $row['username'];
    }
    $i++;
}

// Output the scores and usernames as strings
echo $firstScore . "," . $firstUsername . "," . $secondScore . "," . $secondUsername . "," . $thirdScore . "," . $thirdUsername;

?>


