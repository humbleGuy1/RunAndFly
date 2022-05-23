using UnityEngine;
using TMPro;

public class DestroyableObstacle : MonoBehaviour
{
    [SerializeField] private int _requiredNumberToDestroy;

    private TMP_Text _number;
    private int _destroyedPlayers;

    private void Start()
    {
        _number = GetComponentInChildren<TMP_Text>();
        _number.text = _requiredNumberToDestroy.ToString();
        _destroyedPlayers = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player _))
        {
            _destroyedPlayers++;

            if(_destroyedPlayers == _requiredNumberToDestroy)
            {
                Destroy(gameObject);
            }
        }
    }
}
