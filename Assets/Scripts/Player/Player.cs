using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private ParticleSystem _takeGemEffect;
    [SerializeField] private ParticleSystem _takeKeyEffect;
    [SerializeField] private PlayerGroup _playerGroup;

    private void TakeGem()
    {
        _takeGemEffect.Play();
    }

    private void TakeKey()
    {
        Debug.Log("Take");
        _takeKeyEffect.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Gem gem))
        {
            TakeGem();
            Destroy(gem.gameObject);
        }

        if (other.TryGetComponent(out Key key))
        {
            TakeKey();
            Destroy(key.gameObject);
        }

        if (other.TryGetComponent(out PickUpCharacter character))
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
