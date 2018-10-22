@ECHO OFF
:loop
  cls
  docker ps --format "table {{.Image}}\t{{.Status}}" -f is-task=true
  timeout /t 5 > NUL
goto loop