using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    private Inventory _playerInventory;
    private Camera _camera;
    [SerializeField] private GameObject tooltip;

    void Start()
    {
        _playerInventory = GetComponent<Inventory>();
        _camera = Camera.main;
    }

    private void Update()
    {
        var centerPoint = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight /2, 0);
        Ray ray = _camera.ScreenPointToRay(centerPoint);
        
        if (Physics.Raycast(ray, out var hit))
        {
            tooltip.SetActive(hit.collider.GetComponent<ItemController>());
            if (Input.GetKeyDown(KeyCode.E) && hit.collider.GetComponent<ItemController>())
            {
                _playerInventory.PickUp(hit.collider.GetComponent<ItemController>().Iteam, hit.collider.gameObject);
            }
        }
    }
}