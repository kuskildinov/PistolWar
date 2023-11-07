using UnityEngine;

public class FirstAidKitRoot : CompositeRoot
{
    [SerializeField] private FirstAidKit firstAidKit;

    public override void Compose()
    {
        firstAidKit.Initialize();
    }
}
