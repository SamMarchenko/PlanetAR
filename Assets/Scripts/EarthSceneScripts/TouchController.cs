using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TouchController : MonoBehaviour, IDragHandler, IPointerClickHandler
{
    [SerializeField] private Camera _camera;
    public float speedRotateX = 5;
    public float speedRotateY = 5;
    private float _initialDistance;
    private Vector3 _initialScale;
    public Vector3 InitialScale => _initialScale;
    private float _minScale = 0.3f;
    private float _maxScale = 4f;
    private float _currentDistance;
    private float _factor;

    public Action OnObservatoryClick;


    private void Start()
    {
        _initialScale = transform.localScale;
    }

    private void Update()
    {
        if (Input.touchCount == 2)
        {
            Debug.Log("Scale");
            Scale();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (Input.touchCount == 1)
        {
            Debug.Log("Rotate");
            Rotate();
        }
    }

    private void Scale()
    {
        var firstTouch = Input.GetTouch(0);
        var secondTouch = Input.GetTouch(1);

        if (firstTouch.phase == TouchPhase.Ended || firstTouch.phase == TouchPhase.Canceled ||
            secondTouch.phase == TouchPhase.Ended || secondTouch.phase == TouchPhase.Canceled)
        {
            return;
        }

        if (firstTouch.phase == TouchPhase.Began || secondTouch.phase == TouchPhase.Began)
        {
            _initialDistance = Vector2.Distance(firstTouch.position, secondTouch.position);
        }
        else
        {
            _currentDistance = Vector2.Distance(firstTouch.position, secondTouch.position);
            if (Mathf.Approximately(_initialDistance, 0))
            {
                return;
            }

            _factor = _currentDistance / _initialDistance;
            if (_factor > _maxScale)
            {
                transform.localScale = _initialScale * _maxScale;
            }

            else if (_factor < _minScale)
            {
                transform.localScale = _initialScale * _minScale;
            }
            else
            {
                transform.localScale = _initialScale * _factor;
            }
        }
    }

    private void Rotate()
    {
        float rotX = Input.GetAxis("Mouse X") * speedRotateX * Mathf.Deg2Rad;
        float rotY = Input.GetAxis("Mouse Y") * speedRotateY * Mathf.Deg2Rad;

        if (transform.gameObject.CompareTag("Observatory"))
        {
            if (Mathf.Abs(rotX) > Mathf.Abs(rotY))
                transform.Rotate(Vector3.up * -rotX * 10f);

            Debug.Log("OBS rotate");
        }
        else
        {
            Debug.Log("Planet rotate");
            if (Mathf.Abs(rotX) > Mathf.Abs(rotY))
                transform.RotateAroundLocal(transform.up, -rotX);
            else
            {
                var prev = transform.rotation;
                transform.RotateAround(_camera.transform.right, rotY);
                if (Vector3.Dot(transform.up, _camera.transform.up) < 0.5f)
                    transform.rotation = prev;
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (gameObject.CompareTag("Observatory"))
        {
           OnObservatoryClick?.Invoke();
        }
    }
}