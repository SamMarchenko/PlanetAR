using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ObservatorySceneScripts
{
    public class ObservatoryInfoUIController : MonoBehaviour
    {
        [SerializeField] private GameObject _planeFinderAR;
        [SerializeField] private GameObject _observatoryInfoPanel;
        [SerializeField] private GraphicRaycaster _graphicRaycaster;
        [SerializeField] private Text _closeInfoText;
        [SerializeField] private float _timer = 5f;
        
        private void Start()
        {
            _observatoryInfoPanel.SetActive(true);
            _closeInfoText.gameObject.SetActive(false);
            _planeFinderAR.SetActive(false);
            StartCoroutine(ExecuteAfterTime(_timer));
        }

        private void Update()
        {
            if ( !_graphicRaycaster.enabled)
            {
                return;
            }
            if (Input.touchCount >0 && _closeInfoText.gameObject.activeSelf)
            {
                _planeFinderAR.SetActive(true);
                _observatoryInfoPanel.SetActive(false);
                _graphicRaycaster.enabled = false;
            }
        }

        IEnumerator ExecuteAfterTime(float timer)
        {
            yield return new WaitForSeconds(timer);
            _closeInfoText.gameObject.SetActive(true);
        }
        
    }
}