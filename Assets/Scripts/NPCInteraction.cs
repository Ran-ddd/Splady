using UnityEngine;
using UnityEngine.UI;

public class NPCInteraction : MonoBehaviour
{
    public GameObject bubbleUI;  // ����ð�ݿ�

    private void Start()
    {
        bubbleUI.SetActive(false); // ��ʼʱ����ð�ݿ�
    }

    // ��ҽ��봥������
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // ȷ������� "Player" ��ǩ
        {
            bubbleUI.SetActive(true); // ��ʾð�ݿ�
        }
    }

    // ����뿪��������
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bubbleUI.SetActive(false); // �ر�ð�ݿ�
        }
    }
}
