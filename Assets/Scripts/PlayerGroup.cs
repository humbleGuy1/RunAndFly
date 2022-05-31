using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using DG.Tweening;
using TMPro;

[RequireComponent(typeof(ScaleChanger))]

public class PlayerGroup : MonoBehaviour
{
    [SerializeField] private List<Player> _players;
    [SerializeField] private Player _player;
    [SerializeField] private Vector3 _leadPlayerTargetScale;
    [SerializeField] private ParticleSystem _explosionEffect;
    [SerializeField] private PlayerCounter _playerCounter;
    [SerializeField] private FinishPlatform _finishPlatform;
    
    private ScaleChanger _scaleChanger;
   
    public List<Player> Players => _players;

    public event UnityAction NumberOfPlayersChanged;
    public event UnityAction PlayersWithGemsMovedToPoints;
    public event UnityAction<Player> PlayerWithGemCreated;
    public event UnityAction<Player> CameraMotionStopped;
    public event UnityAction<Player> MinusOneTextShowed;
    public event UnityAction<Player> PlusOneTextShowed;

    private void Start()
    {
        _scaleChanger = GetComponent<ScaleChanger>();
        _playerCounter.transform.SetParent(_players[0].transform, false);
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
        PlusOneTextShowed?.Invoke(_players[0]);
    }

    public void RemoveFirst()
    {
        var leadPlayer = _players[0];

        ActivateEffect(_explosionEffect,leadPlayer);

        _playerCounter.transform.SetParent(_players[1].transform, false);

        _players.RemoveAt(0);
        Destroy(leadPlayer.gameObject);

        leadPlayer = _players[0];
        SwitchControllTo(leadPlayer);
        MinusOneTextShowed?.Invoke(leadPlayer);

        leadPlayer.transform.localScale = _leadPlayerTargetScale;

        CameraMotionStopped?.Invoke(leadPlayer);
        NumberOfPlayersChanged?.Invoke();
    }

    public void RemoveLast()
    {
        int activePlayersCounter = 0;

        foreach(var player in _players)
        {
            if(player.isActiveAndEnabled == true)
            {
                activePlayersCounter++;
            }
        }

        if(activePlayersCounter == 1)
        {
            _finishPlatform.gameObject.SetActive(true);
            MoveLeadPlayerToCenterOfFinishPlatform(_players[0]);
            PlayersWithGemsMovedToPoints?.Invoke();
            var text = _playerCounter.GetComponentInChildren<TMP_Text>();
            text.text = "0";
        }
        else
        {
            for (int i = _players.Count - 1; i >= 0; i--)
            {
                if (_players[i].isActiveAndEnabled == true)
                {
                    _players[i].gameObject.SetActive(false);
                    break;
                }
            }

            NumberOfPlayersChanged?.Invoke();
            PlayerWithGemCreated?.Invoke(_players[0]);
        }
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

    private void MoveLeadPlayerToCenterOfFinishPlatform(Player player)
    {
        var mover = player.GetComponent<PlayerMover>();
        mover.enabled = false;
        float duration = 3f;
        player.transform.DOMove(_finishPlatform.CentralPoint.position, duration);
    }
}
