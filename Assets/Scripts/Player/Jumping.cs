using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Animator))]

public class Jumping : MonoBehaviour
{
    [SerializeField] private float _jumpHeight;
    [SerializeField] private float _duration;

    private Animator _animator;

    private const string Jump = "Jump";

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        int numberOfJums = 1;

        if(other.TryGetComponent(out JumpTrigger trigger))
        {
            transform.DOJump(trigger.EndValue.position, _jumpHeight, numberOfJums, _duration).SetEase(Ease.Linear);
            _animator.Play(Jump);
        }
    }
}
