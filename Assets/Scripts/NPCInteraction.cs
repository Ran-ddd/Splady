using UnityEngine;
using UnityEngine.UI;

public class NPCInteraction : MonoBehaviour
{
    public GameObject bubbleUI;  // 连接冒泡框

    private void Start()
    {
        bubbleUI.SetActive(false); // 开始时隐藏冒泡框
    }

    // 玩家进入触发区域
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // 确保玩家有 "Player" 标签
        {
            bubbleUI.SetActive(true); // 显示冒泡框
        }
    }

    // 玩家离开触发区域
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bubbleUI.SetActive(false); // 关闭冒泡框
        }
    }
}
