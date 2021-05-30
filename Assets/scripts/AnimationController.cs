using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private AudioSource _audioSource;
    private Animator _animator;
    [Range(0, 1)] [SerializeField] private float _weight;
    private GameObject _target;
    [SerializeField] private Vector3 legOffset;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();
    }

    public void Step()
    {
        _audioSource.Play();
    }

    protected void OnAnimatorIK(int layerIndex)
    {
        if (_target)
        {
            _animator.SetIKPosition(AvatarIKGoal.RightHand, _target.transform.position);
            _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, _weight);
            _animator.SetLookAtWeight(_weight);
            _animator.SetLookAtPosition(_target.transform.position);
        }

        var leftFootWeight = _animator.GetFloat("Right_leg");
        var rightFootWeight = _animator.GetFloat("Left_leg");

        var leftfoot = _animator.GetBoneTransform(HumanBodyBones.LeftFoot);
        var rightfoot = _animator.GetBoneTransform(HumanBodyBones.RightFoot);
        SetLegIK(leftfoot, leftFootWeight, AvatarIKGoal.LeftFoot);
        SetLegIK(rightfoot, rightFootWeight, AvatarIKGoal.RightFoot);
    }

    private void SetLegIK(Transform foot, float weight, AvatarIKGoal ikGoal)
    {
        RaycastHit hit;
        if (Physics.Raycast(foot.position, Vector3.down, out hit, 10f))
        {
            _animator.SetIKPosition(ikGoal, hit.point + legOffset);
            _animator.SetIKPositionWeight(ikGoal, weight);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ItemController>())
        {
            _weight = (Vector3.Dot(transform.forward, other.transform.position - transform.position) > 0) ? 0.5f : 0;
            _target = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _weight = 0;
    }

    private void Update()
    {
    }
}