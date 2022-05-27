using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class ShowBaloonsTrigger : MonoBehaviour
{
    [SerializeField] private List<Baloon> baloons;
    [SerializeField] protected float _duration;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player _))
        {
            gameObject.SetActive(false);

            foreach (var baloon in baloons)
            {
                baloon.gameObject.SetActive(true);

                var renderer = baloon.transform.Find("Circle").GetComponent<MeshRenderer>();
                var renderer2 = baloon.transform.Find("Sphere").GetComponent<MeshRenderer>();
                var number = baloon.GetComponentInChildren<TMP_Text>();

                renderer.material.DOFade(0,0);            
                renderer2.material.DOFade(0,0);

                renderer.material.DOFade(255,_duration);
                renderer2.material.DOFade(255,_duration);

            }
        }
    }

}
