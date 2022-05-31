using UnityEngine;

public class Key : PickUpableObject
{
    [SerializeField] private KeysShower _shower;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player _))
        {
            _shower.Show();
            Destroy(gameObject);
        }
    }
}
