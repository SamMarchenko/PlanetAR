using UnityEngine;
using UnityEngine.EventSystems;

namespace ObservatorySceneScripts
{
    public class ObservatoryRotating : MonoBehaviour, IDragHandler
    {
        public float speedRotateX = 5;
        public float speedRotateY = 5;
        
        
        public void OnDrag(PointerEventData eventData)
        {
            if (Input.touchCount == 1)
            {
                Debug.Log("Rotate");
                Rotate();
            }
        }
        
        private void Rotate()
        {
            float rotX = Input.GetAxis("Mouse X") * speedRotateX * Mathf.Deg2Rad;
            float rotY = Input.GetAxis("Mouse Y") * speedRotateY * Mathf.Deg2Rad;
            
                if (Mathf.Abs(rotX) > Mathf.Abs(rotY))
                    transform.Rotate(Vector3.up * -rotX * 10f);

                Debug.Log("OBS rotate");
       
        }
    }
}