<?php

function printLog($message){
    error_log(print_r("$message \n", true), 3, "./etc/php.log");
}

?>

