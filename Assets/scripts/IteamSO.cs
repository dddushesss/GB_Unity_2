using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "iteam", menuName = "Custom/Inventory Item")]
public class IteamSO : ScriptableObject
{
    public enum Type
    {
        Key,
        Sword,
        Poition
    }

    [SerializeField] public Type itemType;
    [SerializeField] public Sprite Texture;
    [SerializeField] public int Val;
    [SerializeField] public GameObject Prefab;
}
