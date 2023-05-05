<?php

$con = mysqli_connect('multistagedb.db', 'ahughes', 'sX6VzxMtrg4*E', 'unityaccess');

    echo("Script executed");
    //check that connection happened
    if (mysqli_connect_errno())
    {
        echo "1: Connection failed"; //error code #1 = connection failed
        exit();
    }

    $username = $_POST["name"];
    $password = $_POST["password"];

    //check if name exists
    $namecheckquery = "SELECT username FROM players WHERE username='" . $username . "';";

    $namecheck = mysqli_query($con, $namecheckquery) or die("2: Name check query failed"); //error code #2 - name check query failed

    if (mysqli_num_rows($namecheck) > 0)
    {
        //Code still returned User created successfully instead of throwing an error when a duplicate was entered (Was not entered into db anyway but wrong message)
        // echo "3: Name already exists"; //error code #3 - name exists cannot register
        // exit();
        $row = mysqli_fetch_assoc($namecheck);
        if ($row['username'] == $username) {
            echo "3: Name already exists"; //error code #3 - name exists cannot register
            exit();
        }
    }

    //add user to the table
    $salt = "\$5\$rounds=5000\$" . "steamedhams" . $username . "\$";
    $hash = crypt($password, $salt);
    $insertuserquery = "INSERT INTO players (username, hash, salt) VALUES ('" . $username . "', '" . $hash . "', '" . $salt . "');";
    mysqli_query($con, $insertuserquery) or die("4: Insert player query failed"); //error code #4 - insert query failed

    echo ("0");

?>
