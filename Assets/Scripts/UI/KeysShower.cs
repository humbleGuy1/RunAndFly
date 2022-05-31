using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class KeysShower : MonoBehaviour
{
    [SerializeField] private List<Image> _images;
    [SerializeField] private Image _goldenKey;
    [SerializeField] private float _fadeDuration;

    private void Start()
    {
        foreach (var image in _images)
        {
            image.DOFade(0, 0);
        }

        _goldenKey.DOFade(0, 0);
    }

    public void Show()
    {
        StartCoroutine(Showing());
    }

    private IEnumerator Showing()
    {
        var waitForSeconds = new WaitForSeconds(0.5f);
        var waitForSeconds2 = new WaitForSeconds(2f);

        foreach (var image in _images)
        {
            image.DOFade(1, _fadeDuration);
        }

        yield return waitForSeconds;

        _goldenKey.DOFade(1, 0);
        _goldenKey.transform.DOScale(15f, 0.5f);

        yield return waitForSeconds;

        _goldenKey.transform.DOScale(12f, 0.5f);

        yield return waitForSeconds2;

        foreach (var image in _images)
        {
            image.DOFade(0, _fadeDuration);
            _goldenKey.DOFade(0, _fadeDuration);
        }
    }
}
