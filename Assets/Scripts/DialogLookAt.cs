using UnityEngine;

public class DialogLookAt : MonoBehaviour
{
    public Transform player; // ���Ŀ��

    void Update()
    {
        if (player != null)
        {
            transform.LookAt(player); // �öԻ��������
        }
    }
}
