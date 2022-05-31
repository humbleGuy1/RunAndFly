using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] private Player _target;
    [SerializeField] private float _value;
    [SerializeField] private float _valueModifier;

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _target.transform.position, _value * Time.deltaTime);
    }

    //public void SetTarget(Player player)
    //{
    //    _target = player;
    //}

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out FlyTrigger _))
        {
            _value *= _valueModifier;
        }

        if (other.TryGetComponent(out RunTrigger _))
        {
            _value /= _valueModifier;
        }
    }
}
