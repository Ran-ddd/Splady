using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System.Text;
using TMPro;

public class AITalk : MonoBehaviour
{
    // �滻Ϊ��� DeepSeek API key
    private string apiKey = "sk-23da920a79774d0bb7cc94cfff304fe4";
    private string apiUrl = "https://api.deepseek.com/chat/completions";

    // Unity UI Ԫ��
    public TMP_InputField userInputField;
    public TextMeshPro chatOutputText;

    // ���ڴ洢�Ի���ʷ
    private List<Dictionary<string, string>> messages = new List<Dictionary<string, string>>();
    void Start()
    {
        // ��ʼ��ϵͳ��Ϣ
        messages.Add(new Dictionary<string, string> { { "role", "system" }, { "content", "��Ľ�ɫ��һ��AR��Ϸ�����������Ļ������С���������������ɫ���ҶԻ�.ʹ�ü�̵����ش��ң���Ҫ��������ţ��û�����3500���ּ�����������20�����ڣ����ɻ�ԾһЩ������20���ڵ�����������20���ڵ�������" } });
    }

    public void OnSendButtonClicked()
    {
        string userMessage = userInputField.text;
        userInputField.text = "";
        if (string.IsNullOrEmpty(userMessage)) return;

        // ����û���Ϣ���Ի���ʷ
        messages.Add(new Dictionary<string, string> { { "role", "user" }, { "content", userMessage } });

        // ���� DeepSeek API
        StartCoroutine(CallDeepSeekAPI());
    }

    private IEnumerator CallDeepSeekAPI()
    {
        // ������������
        var requestData = new
        {
            model = "deepseek-chat",
            messages = messages,
            stream = false
        };

        string jsonData = JsonConvert.SerializeObject(requestData);

        // ���� UnityWebRequest
        UnityWebRequest request = new UnityWebRequest(apiUrl, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("Authorization", "Bearer " + apiKey);

        // ��������
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            // ������Ӧ
            var response = JsonConvert.DeserializeObject<DeepSeekResponse>(request.downloadHandler.text);
            string botMessage = response.choices[0].message.content;

            // ��ʾ��Ӧ
            chatOutputText.text = "" + botMessage;

            // ��� AI ��Ϣ���Ի���ʷ
            messages.Add(new Dictionary<string, string> { { "role", "assistant" }, { "content", botMessage } });
        }
        else
        {
            Debug.LogError("Error: " + request.error);
        }
    }

    [System.Serializable]
    public class DeepSeekResponse
    {
        public Choice[] choices;
    }

    [System.Serializable]
    public class Choice
    {
        public Message message;
    }

    [System.Serializable]
    public class Message
    {
        public string content;
    }
}