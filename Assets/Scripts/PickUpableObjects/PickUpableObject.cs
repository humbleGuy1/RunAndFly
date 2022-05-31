using UnityEngine;

public abstract class PickUpableObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player _))
        {
            Destroy(gameObject);
        }
    }
}
