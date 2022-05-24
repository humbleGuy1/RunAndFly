using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

[RequireComponent(typeof(ScaleChanger))]

public class PlayerGroup : MonoBehaviour
{
    [SerializeField] private List<Player> _players;
    [SerializeField] private Vector3 _leadPlayerTargetScale;
    [SerializeField] protected ParticleSystem _exposionEffect;
    
    private ScaleChanger _scaleChanger;
   
    public List<Player> Players => _players;

    public event UnityAction NumberOfPlayersChanged;
    public event UnityAction<Player> CameraMotionStopped;

    private void Start()
    {
        _scaleChanger = GetComponent<ScaleChanger>();
        NumberOfPlayersChanged?.Invoke();
    }

    public void Add()
    {
        foreach (var player in _players)
        {
            if (player.isActiveAndEnabled == false)
            {
                player.gameObject.SetActive(true);
                break;
            }
        }

        NumberOfPlayersChanged?.Invoke();
        _scaleChanger.Change(_players);
    }

    public void Remove()
    {
        var leadPlayer = _players[0];

        Instantiate(_exposionEffect, leadPlayer.transform);
        leadPlayer.gameObject.SetActive(false);
        _players.RemoveAt(0);

        leadPlayer = _players[0];

        var mover = leadPlayer.GetComponent<PlayerMover>();
        mover.enabled = true;

        var follower = leadPlayer.GetComponent<Follower>();
        follower.enabled = false;
        leadPlayer.transform.localScale = _leadPlayerTargetScale;

        CameraMotionStopped?.Invoke(leadPlayer);
        NumberOfPlayersChanged?.Invoke();
    }
}
