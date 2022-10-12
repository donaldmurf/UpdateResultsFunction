#!/bin/bash
echo "--------Sync git with GitHub--------"
echo "git fetch --all -Pp"
echo 
echo "--------push update to branch--------"
echo "git add ."
echo "git commit -m “comment” "
echo "git push" 
echo 
echo "--------remove and revert uncommited git changes--------"
echo "git reset —hard"
echo "git clean -fxd"
echo 
echo "--------displays help for git LFS--------"
echo "git lfs migrate"
echo 
echo "--------roll back changes--------"
echo "git log —oneline"
echo "git reset <commit ID>" 

