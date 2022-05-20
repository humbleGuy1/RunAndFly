using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _gems;
    [SerializeField] private ParticleSystem _takeGemEffect;

    private void TakeGem()
    {
        _gems++;
        _takeGemEffect.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Gem gem))
        {
            TakeGem();
            Destroy(gem.gameObject);
        }
    }
}
