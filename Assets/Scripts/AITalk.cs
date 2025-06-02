using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System.Text;
using TMPro;

public class AITalk : MonoBehaviour
{
    // 替换为你的 DeepSeek API key
    private string apiKey = "sk-23da920a79774d0bb7cc94cfff304fe4";
    private string apiUrl = "https://api.deepseek.com/chat/completions";

    // Unity UI 元素
    public TMP_InputField userInputField;
    public TextMeshPro chatOutputText;

    // 用于存储对话历史
    private List<Dictionary<string, string>> messages = new List<Dictionary<string, string>>();
    void Start()
    {
        // 初始化系统消息
        messages.Add(new Dictionary<string, string> { { "role", "system" }, { "content", "你的角色是一款AR游戏（竞速恋语）里的机娘（叫做小机），扮演这个角色和我对话.使用简短的语句回答我（不要用特殊符号，用基本的3500汉字集），限制在20字以内，轻松活跃一些，限制20以内的字数，限制20以内的字数。" } });
    }

    public void OnSendButtonClicked()
    {
        string userMessage = userInputField.text;
        userInputField.text = "";
        if (string.IsNullOrEmpty(userMessage)) return;

        // 添加用户消息到对话历史
        messages.Add(new Dictionary<string, string> { { "role", "user" }, { "content", userMessage } });

        // 调用 DeepSeek API
        StartCoroutine(CallDeepSeekAPI());
    }

    private IEnumerator CallDeepSeekAPI()
    {
        // 创建请求数据
        var requestData = new
        {
            model = "deepseek-chat",
            messages = messages,
            stream = false
        };

        string jsonData = JsonConvert.SerializeObject(requestData);

        // 创建 UnityWebRequest
        UnityWebRequest request = new UnityWebRequest(apiUrl, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("Authorization", "Bearer " + apiKey);

        // 发送请求
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            // 解析响应
            var response = JsonConvert.DeserializeObject<DeepSeekResponse>(request.downloadHandler.text);
            string botMessage = response.choices[0].message.content;

            // 显示响应
            chatOutputText.text = "" + botMessage;

            // 添加 AI 消息到对话历史
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