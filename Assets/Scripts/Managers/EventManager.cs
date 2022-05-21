using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public Action<GameObject> RemoveCube;
    public Action<GameObject> AddCube;
    public Action Move;
    public Action SpawnTrack;
    public Action CollisionWall;
    public Action AdditionlProcess;
    public Action Tap;
    public Action Hold;
    public Action EndGame;
    public Action Restart;
    public Action DestroyObjectOnTrack;
    public Action RebuildAdditional;
}
