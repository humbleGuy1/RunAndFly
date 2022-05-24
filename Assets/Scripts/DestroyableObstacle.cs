using UnityEngine;
using TMPro;

public class DestroyableObstacle : MonoBehaviour
{
    [SerializeField] private int _requiredNumberToDestroy;

    private TMP_Text _displayedNumber;

    private void Start()
    {
        _displayedNumber = GetComponentInChildren<TMP_Text>();
        _displayedNumber.text = _requiredNumberToDestroy.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player _))
        {
            _requiredNumberToDestroy--;
            _displayedNumber.text = _requiredNumberToDestroy.ToString();

            if (_requiredNumberToDestroy == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
