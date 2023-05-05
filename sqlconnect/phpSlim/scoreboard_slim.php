<!-- Converted php to phpSlim code -->
<!-- phpSlim framework and MySQLi extension needed for all phpSlim code --> 


<!-- <?php
// use Psr\Http\Message\ResponseInterface as Response;
// use Psr\Http\Message\ServerRequestInterface as Request;
// use Slim\Factory\AppFactory;

// require __DIR__ . '/vendor/autoload.php';

// $app = AppFactory::create();

// $app->get('/leaderboard', function (Request $request, Response $response, $args) {
//     $con = mysqli_connect('multistagedb.db', 'ahughes', 'sX6VzxMtrg4*E', 'unityaccess');

//     // Check that connection happened
//     if (mysqli_connect_errno())
//     {
//         $response->getBody()->write("1: Connection failed"); //error code #1 = connection failed
//         return $response;
//     }

//     // Retrieve the 3 lowest scores and relative usernames from the players table
//     $sql = "SELECT username, score FROM players ORDER BY score ASC LIMIT 3";
//     $result = mysqli_query($con, $sql);

//     // Initialize variables to hold the scores and usernames as strings otherwise I'd have to use json
//     $firstScore = "";
//     $firstUsername = "";
//     $secondScore = "";
//     $secondUsername = "";
//     $thirdScore = "";
//     $thirdUsername = "";

//     // Loop through the results and assign the scores and usernames to the appropriate variables
//     $i = 0;
//     while ($row = mysqli_fetch_assoc($result)) {
//         if ($i == 0) {
//             $firstScore = strval($row['score']);
//             $firstUsername = $row['username'];
//         }
//         else if ($i == 1) {
//             $secondScore = strval($row['score']);
//             $secondUsername = $row['username'];
//         }
//         else if ($i == 2) {
//             $thirdScore = strval($row['score']);
//             $thirdUsername = $row['username'];
//         }
//         $i++;
//     }

//     // Output the scores and usernames as strings
//     $response->getBody()->write($firstScore . "," . $firstUsername . "," . $secondScore . "," . $secondUsername . "," . $thirdScore . "," . $thirdUsername);

//     return $response;
// });

// $app->run();