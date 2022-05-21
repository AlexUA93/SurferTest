using UnityEngine;

public class ModuleInitializer
{
    private Module module;

    public static ModuleInitializer Init()
    {
        var mi = new ModuleInitializer();
        var config = GameConfig.Load();
        var level = config.Levels[0];
        foreach (var module in level.Modules)
        {
            mi.GetByName(module.Type);
            if (module != null)
            {
                mi.module.Init(module.ModuleObjects);
            }
        }

        return mi;
    }

    private void GetByName(ModuleGroupeType moduleGroupeType)
    {
        switch (moduleGroupeType)
        {
            case (ModuleGroupeType.TrackModuleWhitWall):
                module = new TrackModuleWhitWall();
                break;
            case (ModuleGroupeType.CubeInstModule):
                module = new CubeInstModule();
                break;
            default:
                module = null;
                Debug.Log($"Module {moduleGroupeType} not find");
                break;
        }
    }
}
