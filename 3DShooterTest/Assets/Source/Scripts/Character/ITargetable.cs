using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITargetable:IDamageble
{
    public Vector3 Position { get; }
}
