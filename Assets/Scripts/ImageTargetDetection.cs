using UnityEngine;
using Vuforia;
using UnityEngine.UI;

public class ImageTargetDetection : MonoBehaviour
{
    public Button uiButton; // 要显示的UI按钮
    private DefaultObserverEventHandler observerEventHandler;

    void Start()
    {
        // 获取DefaultObserverEventHandler组件
        observerEventHandler = GetComponent<DefaultObserverEventHandler>();
        if (observerEventHandler != null)
        {
            // 订阅跟踪状态改变事件
            observerEventHandler.OnTargetFound.AddListener(OnTargetFound);
            observerEventHandler.OnTargetLost.AddListener(OnTargetLost);
        }

        // 初始时隐藏按钮
        if (uiButton != null)
        {
            uiButton.gameObject.SetActive(false);
        }
    }

    private void OnTargetFound()
    {
        Debug.Log("图像目标已检测到！");
        // 显示UI按钮
        if (uiButton != null)
        {
            uiButton.gameObject.SetActive(true);
        }
    }

    private void OnTargetLost()
    {
        Debug.Log("图像目标已丢失！");
        // 隐藏UI按钮
        if (uiButton != null)
        {
            uiButton.gameObject.SetActive(false);
        }
    }

    public void OnButtonClick()
    {
        Debug.Log("按钮被点击了！");
        // 在这里添加按钮点击后的具体功能
    }
} 