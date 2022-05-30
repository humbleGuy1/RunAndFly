using TMPro;
using UnityEngine;

[RequireComponent(typeof(PlayerGroup))]

public class TextShower : MonoBehaviour
{
    [SerializeField] private PlayerGroup _playerGroup;
    [SerializeField] private TMP_Text _plusOnePrefab;
    [SerializeField] private TMP_Text _minusOnePrefab;

    private void OnMinusOneTextShowed(Player player)
    {
        Instantiate(_minusOnePrefab, player.transform);
    }

    private void OnPlusOneTextShowed(Player player)
    {
        Instantiate(_plusOnePrefab, player.transform);
    }

    private void OnEnable()
    {
        _playerGroup.MinusOneTextShowed += OnMinusOneTextShowed;
        _playerGroup.PlusOneTextShowed += OnPlusOneTextShowed;
    }

    private void OnDisable()
    {
        _playerGroup.MinusOneTextShowed -= OnMinusOneTextShowed;
        _playerGroup.PlusOneTextShowed -= OnPlusOneTextShowed;
    }
}
