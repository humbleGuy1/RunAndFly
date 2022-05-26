using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

[RequireComponent(typeof(ScaleChanger))]

public class PlayerGroup : MonoBehaviour
{
    [SerializeField] private List<Player> _players;
    [SerializeField] private Vector3 _leadPlayerTargetScale;
    [SerializeField] private ParticleSystem _exposionEffect;
    [SerializeField] private PlayerCounter _playerCounter;
    
    private ScaleChanger _scaleChanger;
   
    public List<Player> Players => _players;

    public event UnityAction NumberOfPlayersChanged;
    public event UnityAction<Player> CameraMotionStopped;

    private void Start()
    {
        _playerCounter.transform.SetParent(_players[0].transform, false);
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

        ActivateEffect(_exposionEffect,leadPlayer);

        _playerCounter.transform.SetParent(_players[1].transform, false);

        _players.RemoveAt(0);
        Destroy(leadPlayer.gameObject);

        leadPlayer = _players[0];
        SwitchControllTo(leadPlayer);

        leadPlayer.transform.localScale = _leadPlayerTargetScale;

        CameraMotionStopped?.Invoke(leadPlayer);
        NumberOfPlayersChanged?.Invoke();
    }

    private void ActivateEffect(ParticleSystem effect, Player player)
    {
        var renderer = player.GetComponentInChildren<SkinnedMeshRenderer>();
        Vector3 center = renderer.bounds.center;
        Instantiate(effect, center, player.transform.rotation);
    }

    private void SwitchControllTo(Player player)
    {
        var mover = player.GetComponent<PlayerMover>();
        mover.enabled = true;

        var follower = player.GetComponent<Follower>();
        follower.enabled = false;
    }
}
