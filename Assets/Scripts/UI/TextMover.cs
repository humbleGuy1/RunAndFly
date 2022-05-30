using UnityEngine;
using DG.Tweening;
using TMPro;

[RequireComponent(typeof(TMP_Text))]

public class TextMover : MonoBehaviour
{
    [SerializeField] private float _moveDuration;
    [SerializeField] private float _fadeDuration;
    [SerializeField] private float _yOffset;

    private TMP_Text _text;

    private void Start()
    {
        _text = GetComponent<TMP_Text>();
        transform.DOMoveY(_yOffset, _moveDuration);
        _text.DOFade(0, _fadeDuration);
    }
}
