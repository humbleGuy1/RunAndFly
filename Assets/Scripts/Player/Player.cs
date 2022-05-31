using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerGroup _playerGroup;
    [SerializeField] private ParticleSystem _takeGemEffect;
    [SerializeField] private ParticleSystem _takeKeyEffect;
    [SerializeField] private ParticleSystem _takeBaloonEffect;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Gem _))
        {
            _takeGemEffect.Play();
        }

        if (other.TryGetComponent(out Key _))
        {
            _takeKeyEffect.Play();
        }

        if (other.TryGetComponent(out PickUpCharacter _))
        {
            _playerGroup.Add();
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
