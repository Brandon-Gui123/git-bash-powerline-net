# git-bash-powerline-net

[Powerline](https://github.com/powerline/powerline) for Git Bash, done in C#.

Powerline is great, but I wanted more customizations and also want to use it on Windows.

I ran into 2 powerline repositories by [sschleemilch](https://github.com/sschleemilch). One is done in [C#](https://github.com/sschleemilch/gitbash-powerline) and another one is done in [C++](https://github.com/sschleemilch/cpp-gitbash-powerline).

Diving inside the repositories, I soon learnt how easy it was to create a program to do all the Powerline stuff for you.

So I went ahead to make my own variant.

## Setting Up

1. Head over to the [Releases](https://github.com/Brandon-Gui123/git-bash-powerline-net/releases/download/v0.1.0/GitBashPowerlineNET.zip) page and download **GitBashPowerlineNET.zip** from the version you want.

2. Unzip the zipped file. You should receive 2 files: **git2-a2bde63.dll** and **GitBashPowerlineNET.exe**. These 2 files must be placed beside each other, else the program will fail.

3. Move the files to somewhere convenient.

4. Open up your `.bashrc` file and append the following to it. Make sure to change `path-to-exe` to the path to where you moved the executable:

    ```bash
    function _set_ps1_to_powerline() {
        local last_command_exit_code=$?
        local path_to_exe="change-me-to-the-path-to-the-exe"

        # if the executable doesn't exist, then don't change PS1
        if [[ -e $path_to_exe ]]; then
            PS1_CONTENT="$("$path_to_exe" $last_command_exit_code)"
            PS1="\n$(echo -e $PS1_CONTENT) "
        fi
    }

    PROMPT_COMMAND="_set_ps1_to_powerline; $PROMPT_COMMAND"
    ```

5. Re-launch Git Bash. You may also run `source your-bash-rc` instead, but take note that `PROMPT_COMMAND` will become longer, resulting in more commands to execute and thus, may cause slowdowns.

6. Your Git Bash should now start showing powerline segments like this (some segments might not show up depending on your current directory):

    ![Screenshot of how the powerline segments might look like](screenshots/My%20Own%20Powerline%20Look.png)

    If so, congratulations!

## Features

### User, Current Directory and Prompt Segments

By default, your username, current directory and prompt will be shown.

![Screenshot of how the user and current directory segments look like](screenshots/Standard%20Powerline.png)

### Git Segment

The Git segment is placed on the left after the current directory and displays some information about the Git repository you're in.

By default, it shows the name of the branch you're currently checked out.

![Screenshot of the Git segment](screenshots/My%20Own%20Powerline%20Look.png)

#### Detached

If you are currently checked out on a commit, the Git segment will update and show you the commit ID instead of the branch name.

![Screenshot of Git segment on detached head status](screenshots/Detached%20Git%20Powerline.png)

#### Merge Status

If you're in a middle of a merge, the segment will display an icon to the right.

![Screenshot of Git segment on merge status](screenshots/Merge%20Status%20Git%20Powerline.png)

#### Cherry Picking Status

If you're in the middle of a cherry pick, the segment will display an icon to the right.

![Screenshot of Git segment on cherry-pick status](screenshots/Cherry%20Pick%20Status%20Git%20Powerline.png)

#### Rebasing Status

If you're in the middle of a rebase, the segment will display an icon to the right.

![Screenshot of Git segment on rebase status](screenshots/Rebase%20Status%20Git%20Powerline.png)

#### Revert Status

If you're in the middle of a revert, the segment will display an icon to the right.

![Screenshot of Git segment on revert status](screenshots/Revert%20Status%20Git%20Powerline.png)

### Error Code Segment

If a non-zero error code is produced by the last command, then it will be shown the next time the prompt is displayed.

![Screenshot of segment of powerline showing error code of last program](screenshots/Error%20Code%20Powerline.png)
