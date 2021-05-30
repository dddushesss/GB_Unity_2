using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody[] _rigidbodies;

    private Collider[] _colliders;
    // Start is called before the first frame update
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbodies = GetComponentsInChildren<Rigidbody>();
        _colliders = GetComponentsInChildren<Collider>();
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY |
                                                RigidbodyConstraints.FreezeRotationZ;
        Revive();
    }

    private void SetState(bool state)
    {
        _animator.enabled = state;
        foreach (var bodies in _rigidbodies)
        {
            bodies.isKinematic = state;
        }

        foreach (var collider in _colliders)
        {
            collider.enabled = !state;
        }
    }

    void Death()
    {
        SetState(false);
    }

    void Revive()
    {
        SetState(true);
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.T))
        {
            Death();
        }
        else if(Input.GetKey(KeyCode.Y))
        {
            Revive();
        }
    }
}
