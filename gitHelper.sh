#!/bin/bash
clear
RED='\033[0;31m'
GREEN='\033[0;32m'
NC='\033[0m'
printf "${RED}--------Sync git with GitHub--------${NC}\n"
printf "${GREEN}git fetch --all -Pp\n"
printf "\n"
printf "${RED}--------Push update to branch--------${NC}\n"
printf "${GREEN}git add .\n${NC}"
printf "${GREEN}git commit -m “comment” \n${NC}"
printf "${GREEN}git push\n ${NC}" 
printf "\n"
printf "${RED}--------Remove and revert uncommited git changes--------${NC}\n"
printf "${GREEN}git reset —hard\n${NC}"
printf "${GREEN}git clean -fxd\n${NC}"
printf "\n"
printf "${RED}--------displays help for git LFS--------${NC}\n"
printf "${GREEN}git lfs migrate\n${NC}"
printf "\n"
printf "${RED}--------roll back changes--------${NC}\n"
printf "${GREEN}git log —oneline\n${NC}"
printf "${GREEN}git reset <commit ID>\n${NC}" 

