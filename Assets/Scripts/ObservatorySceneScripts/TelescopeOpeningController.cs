using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ObservatorySceneScripts
{
    public class TelescopeOpeningController : MonoBehaviour, IPointerClickHandler
    {
        private bool _isOpened;
        [SerializeField] private float _openingTime = 1.5f;

        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("Клик по куполу");
            if (_isOpened)
            {
                _isOpened = false;
                transform.DOLocalRotateQuaternion(Quaternion.Euler(80, 0, 0), _openingTime);
                return;
            }

            _isOpened = true;
            transform.DOLocalRotateQuaternion(Quaternion.Euler(0, 0, 0), _openingTime);
        }
    }
}