using System.Collections.Generic;
using UnityEngine;

public class TrackModel : IEnvironmentModel
{
    private const int kMaxCount = 5;
    private const int kMinCount = 1; 

    public void TakeOparation(IEnvironmentView view)
    {
        List<int> count = new List<int>();
        for (int i = 0; i < kMaxCount; i++)
        {
            count.Add(Random.Range(kMinCount, kMaxCount));
        }

        view.Rebuild(GameObgectType.Wall, count);
    }
}
