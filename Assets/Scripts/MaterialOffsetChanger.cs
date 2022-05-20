using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(MeshRenderer))]

public class MaterialOffsetChanger : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private float _yOffset;

    private MeshRenderer _meshRenderer;

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _meshRenderer.material.DOOffset(new Vector2(0, _yOffset), _duration).SetLoops(-1, LoopType.Restart);
    }
}
