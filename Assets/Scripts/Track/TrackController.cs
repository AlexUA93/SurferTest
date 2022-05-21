using System.Collections.Generic;
using UnityEngine;

public class TrackController
{
    private IEnvironmentModel _trackModel;
    private IEnvironmentView _trackView;

    public TrackController(IEnvironmentView view, IEnvironmentModel model)
    {
        _trackView = view;
        _trackModel = model;
    }

    public void Rebuild()
    {
        _trackModel.TakeOparation(_trackView);
    }

}
