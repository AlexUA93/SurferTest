using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "config/gameconfig")]
public class GameConfig : ScriptableObject
{
    public static GameConfig Load()
    {
        var result = Resources.Load<GameConfig>("GameConfig");
        return result;
    }

    [Header("LevelConfiguration")]
    public List<Level> Levels;

   

    [Serializable]
    public sealed class Level
    {
        public int ID;
        public List<ModuleType> Modules;
        public List<TrackEnvironment> TrackEnvironments;
        
    }

    [Serializable]
    public sealed class TrackEnvironment
    {
        public GameObgectType Type;
        public int CountInLine;
    }

    [Serializable]
    public sealed class ModuleType
    {
        public List<GameObject> ModuleObjects;
        public ModuleGroupeType Type;
    }
}
