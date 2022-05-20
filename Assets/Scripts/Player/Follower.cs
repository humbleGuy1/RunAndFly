using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] private Player _target;
    [SerializeField] private float _value;

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(_target.transform.position.x,
            _target.transform.position.y, _target.transform.position.z), _value * Time.deltaTime);
    }
}
