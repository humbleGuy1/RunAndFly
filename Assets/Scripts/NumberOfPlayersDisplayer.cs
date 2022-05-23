using UnityEngine;
using TMPro;

public class NumberOfPlayersDisplayer : MonoBehaviour
{
    [SerializeField] private PlayerGroup _playerGroup;
    [SerializeField] private TMP_Text _number;

    private void OnNumberOfPlayersChanged()
    {
        int activePlayerCount = 0;

        foreach(var player in _playerGroup.Players)
        {
            if(player.isActiveAndEnabled)
            {
                activePlayerCount++;
            }
        }

        _number.text = activePlayerCount.ToString();
    }

    private void OnEnable()
    {
        _playerGroup.NumberOfPlayersChanged += OnNumberOfPlayersChanged;
    }

    private void OnDisable()
    {
        _playerGroup.NumberOfPlayersChanged -= OnNumberOfPlayersChanged;
    }
}
