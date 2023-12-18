using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum GunType
{
    Pull,
    Push,
    Parabole
}
[CreateAssetMenu(fileName = "Gun", menuName = "Project/Gun")]
public class GunScriptableObject :ScriptableObject
{
    public Material gunMaterial;
    public GunType type;
    public string name;
}
