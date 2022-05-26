using UnityEngine;

public class PickUpCharacter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player _))
        {
            Debug.Log("sad");
        }
    }
}
