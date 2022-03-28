using System;
using System.Collections.Generic;
using UnityEngine;

public interface IShape { }

[Serializable]
public class Cube : IShape
{
    public Vector3 size;
}

[Serializable]
public class Thing
{
    public int weight;
}
