<!-- Converted php to phpSlim code -->
<!-- phpSlim framework and MySQLi extension needed for all phpSlim code --> 
<!-- slim/slim and slim/psr7 needed my registration code --> 


<!-- 
// use Psr\Http\Message\ResponseInterface as Response;
// use Psr\Http\Message\ServerRequestInterface as Request;
// use Slim\Factory\AppFactory;

// require __DIR__ . '/../vendor/autoload.php';

// $app = AppFactory::create();
// $app->addErrorMiddleware(true, true, true);

// $app->post('/register', function (Request $request, Response $response, $args) {
//     $con = mysqli_connect('multistagedb.db', 'ahughes', 'sX6VzxMtrg4*E', 'unityaccess');

//     //check that connection happened
//     if (mysqli_connect_errno())
//     {
//         $response->getBody()->write("1: Connection failed"); //error code #1 = connection failed
//         return $response;
//     }

//     $username = $request->getParsedBody()["name"];
//     $password = $request->getParsedBody()["password"];

//     //check if name exists
//     $namecheckquery = "SELECT username FROM players WHERE username='" . $username . "';";

//     $namecheck = mysqli_query($con, $namecheckquery) or die("2: Name check query failed"); //error code #2 - name check query failed

//     if (mysqli_num_rows($namecheck) > 0)
//     {
//         $row = mysqli_fetch_assoc($namecheck);
//         if ($row['username'] == $username) {
//             $response->getBody()->write("3: Name already exists"); //error code #3 - name exists cannot register
//             return $response;
//         }
//     }

//     //add user to the table
//     $salt = "\$5\$rounds=5000\$" . "steamedhams" . $username . "\$";
//     $hash = crypt($password, $salt);
//     $insertuserquery = "INSERT INTO players (username, hash, salt) VALUES ('" . $username . "', '" . $hash . "', '" . $salt . "');";
//     mysqli_query($con, $insertuserquery) or die("4: Insert player query failed"); //error code #4 - insert query failed

//     $response->getBody()->write("0");
//     return $response;
// });

// $app->run();