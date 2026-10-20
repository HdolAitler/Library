@echo off
REM Use Visual Studio's private Git tool path to run the commands
set GIT_PATH="%ProgramFiles%\Microsoft Visual Studio\2026\Community\Common7\IDE\CommonExtensions\Microsoft\TeamFoundation\Team Explorer\Git\cmd\git.exe"
if not exist %GIT_PATH% set GIT_PATH="%ProgramFiles(x86)%\Microsoft Visual Studio\2026\Community\Common7\IDE\CommonExtensions\Microsoft\TeamFoundation\Team Explorer\Git\cmd\git.exe"

echo Staging and committing files...

%GIT_PATH% add Library/Models/Member.cs
%GIT_PATH% commit -m "A1-T12: Member model"

%GIT_PATH% add Library/Data/MemberRepository.cs Library/Controllers/MembersController.cs Library/Views/Members/Index.cshtml Library/Views/Shared/_Layout.cshtml Library/Program.cs
%GIT_PATH% commit -m "A1-T13: member list"

%GIT_PATH% add Library/Views/Members/Create.cshtml
%GIT_PATH% commit -m "A1-T14: add a member"

%GIT_PATH% add Library/Views/Members/Edit.cshtml
%GIT_PATH% commit -m "A1-T15: edit a member"

%GIT_PATH% add Library/Views/Members/Delete.cshtml
%GIT_PATH% commit -m "A1-T16: delete a member"

%GIT_PATH% add .
%GIT_PATH% commit -m "A1-T17a: my own design"

echo Pushing changes to GitHub...
%GIT_PATH% push origin activity-01

echo Done!
pause
