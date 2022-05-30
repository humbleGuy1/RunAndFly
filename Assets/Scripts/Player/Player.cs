using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerGroup _playerGroup;
    [SerializeField] private ParticleSystem _takeGemEffect;
    [SerializeField] private ParticleSystem _takeKeyEffect;
    [SerializeField] private ParticleSystem _takeBaloonEffect;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Gem gem))
        {
            _takeGemEffect.Play();
            Destroy(gem.gameObject);
        }

        if (other.TryGetComponent(out Key key))
        {
            _takeKeyEffect.Play();
            Destroy(key.gameObject);
        }

        if (other.TryGetComponent(out PickUpCharacter character))
        {
            _playerGroup.Add();
            Destroy(character.gameObject);
        }

        if (other.TryGetComponent(out DestroyableObstacle _))
        {
            _playerGroup.RemoveFirst();
        }

        if(other.TryGetComponent(out Baloon baloon))
        {
            _takeGemEffect.Play();
            _takeBaloonEffect.Play();
            baloon.gameObject.SetActive(false);
            _playerGroup.RemoveLast();
        }

    }
}
