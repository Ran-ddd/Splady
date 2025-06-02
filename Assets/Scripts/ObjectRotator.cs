using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    [Tooltip("完成一圈旋转所需的秒数")]
    [SerializeField]
    private float secondsPerRotation = 2f;

    [Tooltip("旋转的轴向")]
    [SerializeField]
    private Vector3 rotationAxis = Vector3.up;

    [Tooltip("是否顺时针旋转")]
    [SerializeField]
    private bool clockwise = true;

    private void Update()
    {
        // 计算每秒需要旋转的角度
        float degreesPerSecond = 360f / secondsPerRotation;
        
        // 根据是否顺时针旋转调整方向
        if (!clockwise)
        {
            degreesPerSecond = -degreesPerSecond;
        }

        // 应用旋转
        transform.Rotate(rotationAxis, degreesPerSecond * Time.deltaTime);
    }

    // 动态设置旋转速度
    public void SetRotationDuration(float seconds)
    {
        if (seconds > 0)
        {
            secondsPerRotation = seconds;
        }
        else
        {
            Debug.LogWarning("旋转时间必须大于0秒！");
        }
    }

    // 设置旋转方向
    public void SetClockwise(bool isClockwise)
    {
        clockwise = isClockwise;
    }

    // 设置旋转轴
    public void SetRotationAxis(Vector3 axis)
    {
        rotationAxis = axis.normalized;
    }
} 