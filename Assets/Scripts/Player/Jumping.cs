using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Animator))]

public class Jumping : MonoBehaviour
{
    [SerializeField] private Transform _endValue;
    [SerializeField] private float _jumpHeight;
    [SerializeField] private float _duration;

    private Animator _animator;

    private const string Jump = "Jump";

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out Springboard _))
        {
            transform.DOJump(_endValue.position, _jumpHeight, 1, _duration).SetEase(Ease.Linear);
            _animator.Play(Jump);
        }
    }
}
