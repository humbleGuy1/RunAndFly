using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Flying : MonoBehaviour
{
    private Animator _animator;

    private const string Fly = "Fly";
    private const string Run = "Run";

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out FlyTrigger _))
        {
            _animator.Play(Fly);
        }

        if (other.TryGetComponent(out RunTrigger _))
        {
            _animator.Play(Run);
        }
    }
}
