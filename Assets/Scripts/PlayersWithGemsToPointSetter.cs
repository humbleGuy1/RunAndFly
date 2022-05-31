using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayersWithGemsToPointSetter : MonoBehaviour
{
    [SerializeField] private PlayerGroup _playerGroup;
    [SerializeField] private List<Transform> _targetPoints;
    [SerializeField] private float _duration;

    private PlayerWithGem[] _players;

    private void OnPlayersWithGemsMovedToPoints()
    {
        _players = FindObjectsOfType<PlayerWithGem>();

        int targetPointNumber = 0;

        foreach (var player in _players)
        {
            var mover = player.GetComponent<PlayerWithGemMover>();
            mover.enabled = false;
            player.transform.DOMove(_targetPoints[targetPointNumber].transform.position, _duration);
            targetPointNumber++;
        }
    }

    private void OnEnable()
    {
        _playerGroup.PlayersWithGemsMovedToPoints += OnPlayersWithGemsMovedToPoints;
    }

    private void OnDisable()
    {
        _playerGroup.PlayersWithGemsMovedToPoints -= OnPlayersWithGemsMovedToPoints;
    }
}
