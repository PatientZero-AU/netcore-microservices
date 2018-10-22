@ECHO OFF
:loop
  cls
  docker ps -f is-task=true
  timeout /t 5 > NUL
goto loop