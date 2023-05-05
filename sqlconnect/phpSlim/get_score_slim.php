<!-- Converted php to phpSlim code --> 
<!-- phpSlim framework and MySQLi extension needed for all phpSlim code --> 


<?php

// use Psr\Http\Message\ResponseInterface as Response;
// use Psr\Http\Message\ServerRequestInterface as Request;
// use Slim\Factory\AppFactory;

// require __DIR__ . '/vendor/autoload.php';

// $app = AppFactory::create();

// $app->get('/score/{username}', function (Request $request, Response $response, array $args) {

//     $username = $args['username'];

//     $con = mysqli_connect('multistagedb.db', 'ahughes', 'sX6VzxMtrg4*E', 'unityaccess');

//     // Check that connection happened
//     if (mysqli_connect_errno()) {
//         $response->getBody()->write("1: Connection failed"); //error code #1 = connection failed
//         return $response->withStatus(500);
//     }

//     // Retrieve the score for the current user
//     $username = mysqli_real_escape_string($con, $username);
//     $sql = "SELECT score FROM players WHERE username = '$username'";
//     $result = mysqli_query($con, $sql);

//     // Checking if the query was successful
//     if (!$result) {
//         $response->getBody()->write("2: Query failed"); //error code #2 = query failed
//         return $response->withStatus(500);
//     }

//     // Check if the user exists
//     if (mysqli_num_rows($result) != 1) {
//         $response->getBody()->write("3: User not found"); //error code #3 = user not found
//         return $response->withStatus(404);
//     }

//     // Get the score and output it as a string
//     $row = mysqli_fetch_assoc($result);
//     $score = $row['score'];
//     $response->getBody()->write($score);

//     return $response;
// });

// $app->run();