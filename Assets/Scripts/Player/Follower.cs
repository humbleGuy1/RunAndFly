using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] private Player _target;
    [SerializeField] private float _value;

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _target.transform.position, _value * Time.deltaTime);
    }
}
