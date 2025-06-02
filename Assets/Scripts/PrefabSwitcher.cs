using UnityEngine;

public class PrefabSwitcher : MonoBehaviour
{
    private GameObject[] childObjects;
    private int currentIndex = 0;

    void Start()
    {
        // 获取所有子物体
        childObjects = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            childObjects[i] = transform.GetChild(i).gameObject;
        }

        // 初始化显示状态
        if (childObjects.Length > 0)
        {
            UpdateVisibility();
        }
        else
        {
            Debug.LogWarning("没有找到子物体！请添加要切换的物体作为子物体。");
        }
    }

    private void UpdateVisibility()
    {
        // 隐藏所有子物体
        for (int i = 0; i < childObjects.Length; i++)
        {
            childObjects[i].SetActive(false);
        }

        // 显示当前索引的子物体
        if (currentIndex >= 0 && currentIndex < childObjects.Length)
        {
            childObjects[currentIndex].SetActive(true);
            Debug.Log($"当前显示的物体：{childObjects[currentIndex].name}");
        }
    }

    // 切换到下一个物体
    public void Next()
    {
        if (childObjects.Length == 0) return;
        
        currentIndex = (currentIndex + 1) % childObjects.Length;
        UpdateVisibility();
    }

    // 切换到上一个物体
    public void Previous()
    {
        if (childObjects.Length == 0) return;
        
        currentIndex--;
        if (currentIndex < 0)
        {
            currentIndex = childObjects.Length - 1;
        }
        UpdateVisibility();
    }
} 