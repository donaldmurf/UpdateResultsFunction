#!/bin/bash
clear
#Colors
RED='\033[0;31m'
GREEN='\033[0;32m'
PURP='\033[0;35m'
NC='\033[0m'
#Alias for shortcut commands alias X=""
alias Sync= "git fetch --all -Pp"
 alias Reset="git reset —hard && git clean -fxd "

printf "${RED}Sync git with GitHub---------------------------|${PURP}Sync${NC}\n"
printf "${GREEN}git fetch --all -Pp\n"
printf "\n"
printf "${RED}Push update to branch--------------------------|${PURP}Send${NC}\n"
printf "${GREEN}git add .\n${NC}"
printf "${GREEN}git commit -m “comment” \n${NC}"
printf "${GREEN}git push\n ${NC}" 
printf "\n"
printf "${RED}Remove and revert uncommited git changes-------|${PURP}Reset${NC}\n"
printf "${GREEN}git reset —hard\n${NC}"
printf "${GREEN}git clean -fxd\n${NC}"
printf "\n"
printf "${RED}Displays help for git LFS----------------------|${PURP}A${NC}\n"
printf "${GREEN}git lfs migrate\n${NC}"
printf "\n"
printf "${RED}Roll back changes------------------------------|${PURP}A${NC}\n"
printf "${GREEN}git log —oneline\n${NC}"
printf "${GREEN}git reset <commit ID>\n${NC}" 

