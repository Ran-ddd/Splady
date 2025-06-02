using UnityEngine;
using Vuforia;
using UnityEngine.InputSystem;

public class ImageTargetButton : MonoBehaviour
{
    private bool isPressed = false;
    private Camera arCamera;
    private Renderer buttonRenderer;

    void Start()
    {
        // 获取AR相机
        arCamera = GameObject.Find("ARCamera").GetComponent<Camera>();
        
        // 获取Cube的渲染器
        buttonRenderer = GetComponent<Renderer>();
        
        // 设置初始颜色为半透明青色
        Material mat = new Material(Shader.Find("Transparent/Diffuse"));
        mat.color = new Color(0, 1, 1, 0.3f);
        buttonRenderer.material = mat;
    }

    void Update()
    {
        if (!IsImageTargetVisible())
            return;

        // 使用新的Input System获取触摸位置
        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.isPressed)
        {
            Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
            
            // 检测手是否遮挡了Cube
            Ray ray = arCamera.ScreenPointToRay(touchPosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform == transform)
            {
                if (!isPressed)
                {
                    isPressed = true;
                    OnButtonPressed();
                }
            }
            else if (isPressed)
            {
                isPressed = false;
                OnButtonReleased();
            }
        }
        else if (isPressed)
        {
            isPressed = false;
            OnButtonReleased();
        }
    }

    bool IsImageTargetVisible()
    {
        var imageTarget = GetComponentInParent<ObserverBehaviour>();
        if (imageTarget != null)
        {
            var targetStatus = imageTarget.TargetStatus;
            return targetStatus.Status == Status.TRACKED;
        }
        return false;
    }

    void OnButtonPressed()
    {
        Debug.Log("按钮被按下了！");
        buttonRenderer.material.color = new Color(1, 0, 0, 0.5f); // 变红
    }

    void OnButtonReleased()
    {
        Debug.Log("按钮被释放了！");
        buttonRenderer.material.color = new Color(0, 1, 1, 0.3f); // 恢复青色
    }
} 