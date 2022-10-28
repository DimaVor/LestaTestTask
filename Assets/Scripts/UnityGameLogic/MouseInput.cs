using UnityEngine;

public class MouseInput : MonoBehaviour
{
    private Camera _mainCamera;
    private bool _canClick = true;
    
    public void SetClick(bool click) => _canClick = click;
    private void Start() => _mainCamera = GetComponent<Camera>();
    private void Update()
    {
        if (!_canClick) return;
        if (Input.GetMouseButtonDown(0)) 
        {
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if(hit.transform.gameObject.TryGetComponent(out IClickable clickable))
                {
                    clickable.OnClick();
                }
            }
        } 
    }
}
