using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public class Jumping : MonoBehaviour
{
    [SerializeField] private float _jumpForce;

    private Animator _animator;
    private Rigidbody _rigidbody;
    //private bool _isOnGround;

    // private const string IsOnGround = "IsOnGround";
    private const string Jump = "Jump";

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out Springboard _))
        {
            _rigidbody.AddForce(Vector3.up *_jumpForce,ForceMode.Impulse);
            _animator.Play(Jump);
        }
    }

    //private void OnCollisionEnter(Collision2D collision)
    //{
    //    if (collision.gameObject.TryGetComponent(out Ground ground))
    //        _isOnGround = true;
    //}
}
