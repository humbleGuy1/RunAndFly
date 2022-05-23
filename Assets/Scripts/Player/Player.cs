using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _gems;
    [SerializeField] private ParticleSystem _takeGemEffect;
    [SerializeField] private PlayerGroup _playerGroup;

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

        if(other.TryGetComponent(out PickUpCharacter character))
        {
            _playerGroup.Add();
            Destroy(character.gameObject);
        }

        if (other.TryGetComponent(out DestroyableObstacle _))
        {
            _playerGroup.Remove();
        }
    }
}
