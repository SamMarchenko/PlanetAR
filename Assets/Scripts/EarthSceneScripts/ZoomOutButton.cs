using UnityEngine;
using UnityEngine.UI;

public class ZoomOutButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TouchController[] _obj;

    private void Awake()
    {
        _button.onClick.AddListener(ZoomOut);
    }

    private void ZoomOut()
    {
        foreach (var obj in _obj)
        {
            obj.transform.localScale = obj.InitialScale;
        }
    }
}
