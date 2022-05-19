using UnityEngine;

public class SideMovementLimiter : MonoBehaviour
{

    [SerializeField] private float _sideBorder;

    private void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -_sideBorder, _sideBorder),
            transform.position.y, transform.position.z);
    }
}