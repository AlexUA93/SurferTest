using System.Collections.Generic;
using UnityEngine;

public abstract class Module 
{
    public abstract void Init(List<GameObject> gameObject);

    public abstract void Start();
}
