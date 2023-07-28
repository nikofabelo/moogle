#!/bin/bash

if [ "$1" == "run" ]; then
  printf "\x1b[1;31;43mYOU MUST HAVE dotnet v6.0 CORRECTLY INSTALLED IN ORDER TO DEPLOY THIS PROGRAM!\x1b[0m\n"
  cd .. && make dev
elif [ "$1" == "report" ]; then
  if [[ $(uname) == "Linux" ]]; then
    cd ../informe && latexmk && cd ../script
  else
    cd ../informe && pdflatex main.tex && cd ../script
  fi
elif [ "$1" == "slides" ]; then
  if [[ $(uname) == "Linux" ]]; then
    cd ../presentacion && latexmk && cd ../script
  else
    cd ../presentacion && pdflatex main.tex && cd ../script
  fi
elif [ "$1" == "show_report" ]; then
  if [[ $(uname) == "Linux" ]]; then
    cd ../informe && latexmk && xdg-open main.pdf && cd ../script
  else
    if [[ $(uname) == *"NT"* ]]; then
      cd ../informe && pdflatex main.tex && start main.pdf && cd ../script
    else
      cd ../informe && pdflatex main.tex && open main.pdf && cd ../script
    fi
  fi
elif [ "$1" == "show_slides" ]; then
  if [[ $(uname) == "Linux" ]]; then
    cd ../presentacion && latexmk && xdg-open main.pdf && cd ../script
  else
    if [[ $(uname) == *"NT"* ]]; then
      cd ../presentacion && pdflatex main.tex && start main.pdf && cd ../script
    else
      cd ../presentacion && pdflatex main.tex && open main.pdf && cd ../script
    fi
  fi
elif [ "$1" == "clean" ]; then
  cd ../informe && rm -rf *.aux *.fdb_latexmk *.fls *.log *.nav *.vrb *.snm *.toc *.pdf
  cd ../presentacion && rm -rf *.aux *.fdb_latexmk *.fls *.log *.nav *.vrb *.snm *.toc *.pdf sections/*.aux && cd ../script
else
  printf "Provide an argument:\nrun\nreport\nslides\nshow_report\nshow_slides\nclean\n"
fi
