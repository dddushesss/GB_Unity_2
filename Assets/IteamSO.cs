using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "iteam", menuName = "Custom/Inventory Item")]
public class IteamSO : ScriptableObject
{
    enum Type
    {
        Key,
        Sword,
        Poition
    }

    [SerializeField] private Texture Texture;
    [SerializeField] private int Val;
}
