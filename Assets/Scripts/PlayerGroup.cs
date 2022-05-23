using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

[RequireComponent(typeof(ScaleChanger))]

public class PlayerGroup : MonoBehaviour
{
    [SerializeField] private List<Player> _players;
    
    private ScaleChanger _scaleChanger;
   
    public List<Player> Players => _players;

    public event UnityAction NumberOfPlayersChanged;

    private void Start()
    {
        _scaleChanger = GetComponent<ScaleChanger>();
        NumberOfPlayersChanged?.Invoke();
    }

    public void Add()
    {
        foreach (var player in _players)
        {
            if(player.isActiveAndEnabled == false)
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
        _players[0].gameObject.SetActive(false);
        _players.RemoveAt(0);

        var mover = _players[0].GetComponent<PlayerMover>();
        mover.enabled = true;

        var follower = _players[0].GetComponent<Follower>();
        follower.enabled = false;

        NumberOfPlayersChanged?.Invoke();
    }
}
