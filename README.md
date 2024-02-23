# Battle Themes Config Template Project
## Getting Started (No Visual Studio)
This assumes you already have a BGME Battle Themes mod set up and you want to add a config to it.

Before starting, move any configurable themes to: **MOD_FOLDER/battle-themes/options/**

1. Fork the project then open **Mod.cs** on Github for editing.
2. Follow the instructions for adding new settings.
3. Commit your changes to your fork.
4. Click on the **Actions** tab above.
5. On the left side of the page, under **Workflows**, click **Build and Publish Reloaded Mod**.
6. Click the **Run Workflow** button and run the workflow.
7. Once it's finished running (about 2-5 minutes usually) click on the latest run at the top.
8. Under **Artifacts** click and download the **Github Release** zip file.
9. After extracting, copy and paste the following files to your mod folder:
    * **BGME.BattleThemes.Interface.dll**
    * **BGME.BattleThemes.Config.dll**
    * **BattleThemes.Template.dll** <- Main file for config.
10. If you make any changes to the config, the only file you need to update in the future is **BattleThemes.Template.dll**.
11. In your mod folder, open the file **ModConfig.json** in a text editor.
12. Replace the line `"ModDll": "",` with `"ModDll": "BattleThemes.Template.dll",`.
13. Restart **Reloaded** and the **Open Config** button should be available for you mod now.
