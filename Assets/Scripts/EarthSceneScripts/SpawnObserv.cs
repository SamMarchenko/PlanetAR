using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnObserv : MonoBehaviour, IPointerClickHandler
{
    public GameObject Observatory;

    private void Start()
    {
        Observatory.SetActive(false);
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        if (!Observatory.activeSelf)
        {
            Observatory.SetActive(true);
            JumpObject(Observatory);
        }
    }

    private void JumpObject(GameObject obj)
    {
        obj.transform.DOLocalJump(new Vector3(0, 0.5f, 0), 10f, 1, 2);
    }
}