using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProcessRoot : CompositeRoot
{
    private const int NormalTimeScale = 1;
    private const int PauseTimeScale = 0;
    public override void Compose()
    {
        Time.timeScale = NormalTimeScale;
    }
}
