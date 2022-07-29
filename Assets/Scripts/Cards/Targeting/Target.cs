using System;
using UnityEngine;

[Serializable]
public class Target
{
    public TargetType targetType = TargetType.None;
    public Alliance alliance = Alliance.None;
    public bool isTargeted = false;
    [HideInInspector] public BaseCard selected;
}
