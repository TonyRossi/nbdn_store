param($NewBranch)

git add -A
git commit
git checkout master
git pull jp master
git checkout -b $NewBranch

