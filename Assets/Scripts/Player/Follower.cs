using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] private Player _target;
    [SerializeField] private float _followSpeed;
    [SerializeField] private float _followSpeedModifier;

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _target.transform.position, _followSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out FlyTrigger _))
        {
            _followSpeed *= _followSpeedModifier;
        }

        if (other.TryGetComponent(out RunTrigger _))
        {
            _followSpeed /= _followSpeedModifier;
        }
    }
}
