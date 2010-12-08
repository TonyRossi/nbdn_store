$message = read-host "Commit Message"
$branchname = Get-Date -format M.d-hh.mm
git add -A
git commit -m "$message"
git checkout master
git checkout -b $branchname
git pull jp master
