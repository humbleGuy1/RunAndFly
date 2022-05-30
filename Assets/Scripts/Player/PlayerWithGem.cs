using UnityEngine;

public class PlayerWithGem : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _sideSpeed;
    [SerializeField] private float _downSpeed;

    private Vector3 _randomSideVector;

    private void Start()
    {
        _randomSideVector = Random.value < 0.5f ? Vector3.left : Vector3.right;        
    }

    private void Update()
    {
        transform.Translate((Vector3.forward * _speed + _randomSideVector * _sideSpeed + Vector3.down * _downSpeed) 
            * Time.deltaTime, Space.World);
    }
}
