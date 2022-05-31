using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]

public class ShowBaloonsTrigger : MonoBehaviour
{
    [SerializeField] private List<Baloon> _baloons;
    [SerializeField] protected float _duration;

    private BoxCollider _boxCollider;
    private const string Rope = "Rope";
    private const string Sphere = "Sphere";

    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player _))
        {
            StartCoroutine(Show());
            _boxCollider.enabled = false;
        }
    }

    private IEnumerator Show()
    {
        foreach (var baloon in _baloons)
        {
            baloon.gameObject.SetActive(true);

            var ropeRenderer = baloon.transform.Find(Rope).GetComponent<MeshRenderer>();
            var baloonRenderer = baloon.transform.Find(Sphere).GetComponent<MeshRenderer>();
            var number = baloon.GetComponentInChildren<TMP_Text>();

            ropeRenderer.material.DOFade(0, 0);
            baloonRenderer.material.DOFade(0, 0);
            number.DOFade(0, 0);

            ropeRenderer.material.DOFade(1, _duration);
            baloonRenderer.material.DOFade(1, _duration);
            number.DOFade(1, _duration);

            yield return new WaitUntil(() => baloon == null);
        }
    }
}
