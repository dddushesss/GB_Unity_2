using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<IteamSO> _items;

    public void PickUp(IteamSO iteamSo)
    {
        _items.Add(iteamSo);
        Destroy(iteamSo.Prefab);
    }

    public void Drop(IteamSO iteamSo)
    {
        _items.Remove(iteamSo);
        Instantiate(iteamSo.Prefab);
    }
}
