using UnityEngine;

public class Creator : MonoBehaviour
{
    [SerializeField] private PlayerGroup _playerGroup;
    [SerializeField] private PlayerWithGem _playerWithGem;

    private void OnPlayerWithGemCreated(Player player)
    {
        Instantiate(_playerWithGem, player.transform.position, Quaternion.Euler(40,0,0));
    }

    private void OnEnable()
    {
        _playerGroup.PlayerWithGemCreated += OnPlayerWithGemCreated;
    }

    private void OnDisable()
    {
        _playerGroup.PlayerWithGemCreated -= OnPlayerWithGemCreated;
    }
}