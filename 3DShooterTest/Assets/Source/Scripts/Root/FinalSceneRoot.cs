using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalSceneRoot : CompositeRoot
{
    [SerializeField] private FinalScoreView _finalScoreView;
    public override void Compose()
    {
        _finalScoreView.Initialize();
    }
}
