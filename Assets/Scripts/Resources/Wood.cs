using UnityEngine;
using System.Collections;

[System.Serializable]
public class Wood {

    public enum Abilities { buildUnits, techSupport, scienceSupport }
    public Abilities ability { get; set; }
    public enum Potencies { light, middle, heavy, super }
    public Potencies potency { get; set; }
}
