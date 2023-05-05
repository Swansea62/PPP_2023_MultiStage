<!-- Converted php to phpSlim code -->
<!-- phpSlim framework and MySQLi extension needed for all phpSlim code --> 

<!-- <?php
// use Psr\Http\Message\ResponseInterface as Response;
// use Psr\Http\Message\ServerRequestInterface as Request;
// use Slim\Factory\AppFactory;

// require __DIR__ . '/vendor/autoload.php';

// $app = AppFactory::create();

// $app->post('/login', function (Request $request, Response $response, array $args) {

//     $con = mysqli_connect('multistagedb.db', 'ahughes', 'sX6VzxMtrg4*E', 'unityaccess');

//     //check that connection happened
//     if (mysqli_connect_errno()) {
//         $response->getBody()->write("1: Connection failed"); //error code #1 = connection failed
//         return $response->withStatus(500);
//     }

//     $username = $request->getParsedBody()['name'];
//     $password = $request->getParsedBody()['password'];

//     //check if name exists
//     $namecheckquery = "SELECT username, salt, hash, score FROM players WHERE username='" . $username . "';";
//     $namecheck = mysqli_query($con, $namecheckquery);

//     if (!$namecheck) {
//         $response->getBody()->write("2: Name check query failed"); //error code #2 - name check query failed
//         return $response->withStatus(500);
//     }

//     if (mysqli_num_rows($namecheck) != 1) {
//         $response->getBody()->write("5: Either no user with name, or more than one"); //error code #5 - number of names matching != 1
//         return $response->withStatus(404);
//     }

//     //get login info from query
//     $existinginfo = mysqli_fetch_assoc($namecheck);
//     $salt = $existinginfo["salt"];
//     $hash = $existinginfo["hash"];

//     $loginhash = crypt($password, $salt);
//     if ($hash != $loginhash) {
//         $response->getBody()->write("6: Incorrect password"); //error code #6 - password does not hash to match table
//         return $response->withStatus(401);
//     }

//     $response->getBody()->write("0\t" . $existinginfo["score"]);

//     return $response;
// });

// $app->run();