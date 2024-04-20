﻿using BattleThemes.Template.Template;
using BattleThemes.Template.Template.Configuration;
using BGME.BattleThemes.Config;
using Reloaded.Hooks.ReloadedII.Interfaces;
using Reloaded.Mod.Interfaces;
using System.ComponentModel;

namespace BattleThemes.Template;

public class Mod : ModBase
{
    private readonly IModLoader modLoader;
    private readonly IReloadedHooks? hooks;
    private readonly ILogger log;
    private readonly IMod owner;

    private Config config;
    private readonly IModConfig modConfig;

    private readonly ThemeConfig themeConfig;

    public Mod(ModContext context)
    {
        this.modLoader = context.ModLoader;
        this.hooks = context.Hooks;
        this.log = context.Logger;
        this.owner = context.Owner;
        this.config = context.Configuration;
        this.modConfig = context.ModConfig;

        this.themeConfig = new(this.modLoader, this.modConfig, this.config, this.log);

        /* Connect the battle theme files to the config. */
        /* Steps:
         * 1. Place battle theme files in: MOD_FOLDER/battle-themes/options
         * 2. Add a config setting for it in: public class Config : Configurable<Config>
         * 3. Edit/copy and paste the line below with your new setting and the theme file it enables.
         * 
         * For example, right now the config has a "P4G" setting which enables "p4g.theme.pme" in the options folder.
         */

        this.themeConfig.AddSetting(nameof(this.config.P4G), "p4g.theme.pme");
        this.themeConfig.AddSetting(nameof(this.config.KPOP), "kpop.theme.pme");


        /*-------------------------------------------------------*/
        this.themeConfig.Initialize();
    }

    #region Standard Overrides
    public override void ConfigurationUpdated(Config configuration)
    {
        // Apply settings from configuration.
        // ... your code here.
        config = configuration;
        log.WriteLine($"[{modConfig.ModId}] Config Updated: Applying");
    }
    #endregion

    #region For Exports, Serialization etc.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public Mod() { }
#pragma warning restore CS8618
    #endregion
}

public class Config : Configurable<Config>
{
    /* ADD CONFIG SETTINGS HERE */
    [Category("K POP")]
    [DisplayName("Display Name K POP")]
    [Description("Description K POP")]
    [DefaultValue(true)]
    public bool KPOP { get; set; } = true;
    
    [Category("Persona 4 Golden")]
    [DisplayName("Time To Make History / Reach Out To The Truth (Persona 4 Golden)")]
    [Description("Context dependent battle music from Persona 4 Golden. Normal\nbattles will play Time To Make History, while\nadvantage battles will play Reach Out To The Truth.\n\nBattle theme: Time To Make History\nAdvantage battle theme: Reach Out To The Truth\nVictory theme: Period")]
    [DefaultValue(true)]
    public bool P4G { get; set; } = true;
}
