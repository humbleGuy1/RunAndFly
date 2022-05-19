using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _sideShiftSpeed;

    private Animator _animator;
    private Rigidbody _rigidbody;
    private bool _isOnGround;
    private const string Dancing = "Dancing";
    private const string IsOnGround = "IsOnGround";

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
        //_animator.SetBool(IsOnGround, _isOnGround);
    }

    private void Move()
    {
        transform.Translate(_speed * Time.deltaTime * Vector3.forward);

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(_sideShiftSpeed * Time.deltaTime * Vector3.left, Space.World);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(_sideShiftSpeed * Time.deltaTime * Vector3.right, Space.World);
        }
    }

    //private void RotateY(float degree)
    //{
    //    transform.DORotate(new Vector3(0, degree, 0), _rotationdDuration);
    //}

    //private void JumpAfterSteppingOnplatform()
    //{
    //    _rigidbody.AddForce(Vector3.forward + Vector3.up * _jumpForcePlatform, ForceMode.Impulse);
    //    _isOnGround = false;
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.TryGetComponent(out Platform _))
    //    {
    //        JumpAfterSteppingOnplatform();
    //    }
    //}

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.TryGetComponent(out Ground _))
    //    {
    //        _isOnGround = true;
    //    }
    //}
}
