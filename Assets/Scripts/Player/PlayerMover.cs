using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _sideShiftSpeed;
    [SerializeField] private float _flyingSpeedMultiplier;

    private void Update()
    {
        Move();
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out FlyTrigger _))
        {
            _speed *= _flyingSpeedMultiplier;
        }

        if (other.TryGetComponent(out RunTrigger _))
        {
            _speed /= _flyingSpeedMultiplier;
        }
    }
}
