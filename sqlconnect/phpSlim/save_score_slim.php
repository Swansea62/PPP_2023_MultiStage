<!-- Converted php to phpSlim code -->
<!-- phpSlim framework and MySQLi extension needed for all phpSlim code --> 


<!-- <?php
// use Psr\Http\Message\ResponseInterface as Response;
// use Psr\Http\Message\ServerRequestInterface as Request;
// use Slim\Factory\AppFactory;

// require __DIR__ . '/vendor/autoload.php';

// $app = AppFactory::create();

// $app->post('/update-score', function (Request $request, Response $response, $args) {
//     $con = mysqli_connect('multistagedb.db', 'ahughes', 'sX6VzxMtrg4*E', 'unityaccess');

//     // Get the score from the request parameters
//     $username = $request->getParsedBody()['username'];
//     $score = $request->getParsedBody()['score'];

//     // Check that connection happened
//     if (mysqli_connect_errno())
//     {
//         $response->getBody()->write("1: Connection failed"); //error code #1 = connection failed
//         return $response;
//     }

//     // Check if the new score is lower than the current score for the player
//     $sql = "SELECT score FROM players WHERE username = '$username'";
//     $result = mysqli_query($con, $sql);

//     if (mysqli_num_rows($result) > 0) {
//         $row = mysqli_fetch_assoc($result);
//         $currentScore = (float) $row['score'];

//         if ($score < $currentScore) {
//             // Update the score in the database
//             $sql = "UPDATE players SET score = $score WHERE username = '$username'";
//             $result = mysqli_query($con, $sql);

//             if ($result) {
//                 if (mysqli_affected_rows($con) > 0) {
//                     $response->getBody()->write("Score updated successfully");
//                 } else {
//                     $response->getBody()->write("No matching record found for username $username");
//                 }
//             } else {
//                 $response->getBody()->write("Error updating score: " . mysqli_error($con));
//             }
//         } else {
//             $response->getBody()->write("New score is not lower than current score for username $username");
//         }
//     } else {
//         $response->getBody()->write("No matching record found for username $username");
//     }

//     return $response;
// });

// $app->run();