using UnityEngine;

public class ObjectManager 
{
    public static GameObject FindByTag(string tag)
    {
        var go = GameObject.FindGameObjectsWithTag(tag);
        return go.Length > 0 ? go[0] : null;
    }
}
