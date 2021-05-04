using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Inventory : MonoBehaviour
{
    private List<IteamSO> _items;
    [SerializeField] private GameObject _iconPrefab;
    [SerializeField] private GameObject _iconGroup;

    private void Start()
    {
        _items = new List<IteamSO>();
        GetComponent<FirstPersonController>().m_MouseLook.SetCursorLock(!_iconGroup.activeSelf);
    }

    public void PickUp(IteamSO iteamSo, GameObject gameObject)
    {
        _items.Add(iteamSo);
        _iconPrefab.GetComponent<Image>().sprite = iteamSo.Texture;
        _iconPrefab.GetComponent<ItemController>().Iteam = iteamSo;
        _iconPrefab.GetComponent<Button>().onClick.AddListener(delegate { Drop(iteamSo); });
        Instantiate(_iconPrefab, _iconGroup.transform);
        Destroy(gameObject);
    }

    private void Drop(IteamSO iteamSo)
    {
        _items.Remove(iteamSo);
        Instantiate(iteamSo.Prefab, transform.position, Quaternion.identity);
        for (int i = 0;  i < _iconGroup.transform.childCount; i++)
        {
            if (_iconGroup.transform.GetChild(i).gameObject.GetComponent<ItemController>().Iteam.Equals(iteamSo))
            {
                Destroy(_iconGroup.transform.GetChild(i).gameObject);
            }
        }
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            _iconGroup.SetActive(!_iconGroup.activeSelf);
            GetComponent<FirstPersonController>().enabled = !_iconGroup.activeSelf;
            GetComponent<FirstPersonController>().m_MouseLook.SetCursorLock(!_iconGroup.activeSelf);
        }
    }
}
