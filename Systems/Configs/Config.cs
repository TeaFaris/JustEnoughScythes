using System;
using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace JustEnoughSickles.Systems.Configs
{
    public class Config : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [Header("Config")]
        [Label("Toggle UI")]
        [Tooltip("Toggle User Interface, or like this bars that's showing you how many souls you have.")]
        [DefaultValue(true)]
        public bool EnableUI;

        [Label("UI Position X")]
        [Tooltip("The x position of those bars that's showing you your souls.")]
        [Range(0, 1920)]
        [DefaultValue(1920)]
        public int UIXPos;

        [Label("UI Position Y")]
        [Tooltip("The y position of those bars that's showing you your souls.")]
        [Range(0, 1080)]
        [DefaultValue(1080)]
        public int UIYPos;
    }
}
