using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ScaleChanger : MonoBehaviour
{
    [SerializeField] private Vector3 _startScale;
    [SerializeField] private Vector3 _targetScale;
    [SerializeField] private float _duration;
    [SerializeField] private float _delayBetweenPlayers;

    public void Change(List<Player> players)
    {
        StartCoroutine(Changing(players));
    }

    private IEnumerator Changing(List<Player> players)
    {
        var waitForSeconds = new WaitForSeconds(_delayBetweenPlayers);

        foreach (var player in players)
        {
            player.transform.DOScale(_targetScale, _duration);
            player.transform.DOScale(_startScale, _duration);
            yield return waitForSeconds;
        }
    }
}
