<?php

$con = mysqli_connect('multistagedb.db', 'ahughes', 'sX6VzxMtrg4*E', 'unityaccess');

// Check that connection happened
if (mysqli_connect_errno())
{
    echo "1: Connection failed"; //error code #1 = connection failed
    exit();
}

// Retrieve the score for the current user
$username = mysqli_real_escape_string($con, $_POST['username']);
$sql = "SELECT score FROM players WHERE username = '$username'";
$result = mysqli_query($con, $sql);

// Checking if the query was successful
if (!$result) {
    echo "2: Query failed"; //error code #2 = query failed
    exit();
}

// Check if the user exists
if (mysqli_num_rows($result) != 1) {
    echo "3: User not found"; //error code #3 = user not found
    exit();
}

// Get the score and output it as a string
$row = mysqli_fetch_assoc($result);
$score = $row['score'];
echo $score;

?>
