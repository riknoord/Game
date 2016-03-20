using UnityEngine;
using System.Collections;

[System.Serializable]
public class Resource
{
    public enum type { Wood, Stone, Metal };
    public type ResourceType;

    public int Amount;
}
