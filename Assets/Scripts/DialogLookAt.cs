using UnityEngine;

public class DialogLookAt : MonoBehaviour
{
    public Transform player; // 玩家目标

    void Update()
    {
        if (player != null)
        {
            transform.LookAt(player); // 让对话框朝向玩家
        }
    }
}
