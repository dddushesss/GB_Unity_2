using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private List<IteamSO> _items;
    [SerializeField] private GameObject _iconPrefab;
    [SerializeField] private GameObject _iconGroup;
    [SerializeField] private GameObject _tooltip;

    private void Start()
    {
        _items = new List<IteamSO>();
    }

    public void PickUp(IteamSO iteamSo, GameObject gameObject)
    {
        _items.Add(iteamSo);
        _iconPrefab.GetComponent<Image>().sprite = iteamSo.Texture;
        _iconPrefab.GetComponent<ItemController>().Item = iteamSo;
        _iconPrefab.GetComponent<Button>().onClick.AddListener(delegate { Drop(iteamSo); });
        Instantiate(_iconPrefab, _iconGroup.transform);
        Destroy(gameObject);
    }

    private void Drop(IteamSO itemSo)
    {
        _items.Remove(itemSo);
        Instantiate(itemSo.Prefab, transform.position, Quaternion.identity);
        for (int i = 0;  i < _iconGroup.transform.childCount; i++)
        {
            if (_iconGroup.transform.GetChild(i).gameObject.GetComponent<ItemController>().Item.Equals(itemSo))
            {
                Destroy(_iconGroup.transform.GetChild(i).gameObject);
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<ItemController>())
        {
            _tooltip.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<ItemController>())
        {
            _tooltip.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                PickUp(other.GetComponent<ItemController>().Item, other.gameObject);
                _tooltip.SetActive(false);
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            _iconGroup.SetActive(!_iconGroup.activeSelf);
        }
    }
}

