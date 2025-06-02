using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChangeButton : MonoBehaviour
{
    private Button button;
    
    // 在Inspector中可以选择要跳转的场景
    [SerializeField]
    private string targetScene = "AphexLocalLobby";
    
    // 场景列表，用于在Inspector中选择
    public enum SceneOptions
    {
        SampleScene,
        AphexLocalLobby,
        Aphex,
        Oval,
        TinyCarsLocalLobby,
        TheBean,
        TheBridge,
        LoadingScreen
    }
    
    [SerializeField]
    private SceneOptions selectedScene = SceneOptions.AphexLocalLobby;

    void Start()
    {
        // 获取按钮组件
        button = GetComponent<Button>();
        
        // 添加点击事件监听
        if (button != null)
        {
            button.onClick.AddListener(OnButtonClick);
        }
        
        // 根据选择的枚举设置目标场景
        UpdateTargetScene();
    }

    private void UpdateTargetScene()
    {
        switch (selectedScene)
        {
            case SceneOptions.AphexLocalLobby:
                targetScene = "AphexLocalLobby";
                break;
            case SceneOptions.TinyCarsLocalLobby:
                targetScene = "TinyCarsLocalLobby";
                break;
            case SceneOptions.SampleScene:
                targetScene = "SampleScene";
                break;
        }
    }

    // 在Inspector中修改选项时自动更新目标场景
    private void OnValidate()
    {
        UpdateTargetScene();
    }

    public void OnButtonClick()
    {
        Debug.Log($"正在切换到场景：{targetScene}");
        SceneManager.LoadScene(targetScene);
    }

    void OnDestroy()
    {
        // 移除监听器，防止内存泄漏
        if (button != null)
        {
            button.onClick.RemoveListener(OnButtonClick);
        }
    }
} 