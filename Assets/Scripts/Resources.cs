using UnityEngine;

public static class Resources
{
    public static class Scenes
    {
        public const string MainScene = "MainScene";
    }

    public static class Various
    {
        public static string TankChassis = "TankChassis";
        public static string TankTracksLeft = "TankTracksLeft";
        public static string TankTracksRight = "TankTracksRight";
        public static string TankTurret = "TankTurret";
        public static string UI = "UI";
    }
    
    public static class Events
    {
        public const string PlayerDead = "PlayerDead";
    }
    
    public static class Layers
    {
        public const string Buildings = "Buildings";
        public const string GisPlayers = "GisPlayers";
        public const string SapPlayers = "SapPlayers";
        public const string Minimap = "Minimap";
    }

    public static class Tags
    {
        public const string GisPlayer = "GisPlayer";
        public const string SapPlayer = "SapPlayer";
        public const string MapCenter = "MapCenter";
        public const string Ground = "Ground";
    }
}
