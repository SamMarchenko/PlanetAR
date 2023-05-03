using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObservatoryController : MonoBehaviour, IPointerClickHandler, IPointerDownHandler
{
    [SerializeField] private Camera _camera;
    public float speedRotateX = 1;
    public float speedRotateY = 1;
    public int Value = 2;

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        if (!Input.GetMouseButton(0))
            return;

        //float rotX = Input.GetAxis("Mouse X") * speedRotateX * Mathf.Deg2Rad;
        float rotY = Input.GetAxis("Mouse Y") * speedRotateY * Mathf.Deg2Rad;

        // if (Mathf.Abs(rotX) > Mathf.Abs(rotY))
        //     transform.RotateAroundLocal(transform.up, -rotX);
        // else
        // {
        var prev = transform.rotation;
        transform.RotateAround(_camera.transform.right, rotY);
        if (Vector3.Dot(transform.up, _camera.transform.up) < 0.5f)
            transform.rotation = prev;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        transform.DOScale(Vector3.zero, 1f);
        transform.gameObject.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
    }
}