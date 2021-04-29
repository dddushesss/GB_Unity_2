using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField] private IteamSO Iteam;

    private void Start()
    {
        Instantiate(Iteam.Prefab, transform);
    }
}
