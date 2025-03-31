using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public Transform playerBody; // 角色主体
    public Transform cameraBody;
    public float mouseSensitivity = 2f; // 鼠标灵敏度

    private float pitch = 0f; // 记录摄像机的俯仰角

    public void Init()
    {
        Camera.main.transform.SetParent(cameraBody, false);
        Camera.main.transform.localPosition = Vector3.zero;
        Camera.main.transform.localEulerAngles = Vector3.zero;
    }

    void Update()
    {
        HandleMouseLook();
    }

    void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // 角色水平旋转
        playerBody.Rotate(Vector3.up * mouseX);

        // 摄像机垂直旋转（俯仰角）
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, -90f, 90f); // 限制视角，防止翻转
        Camera.main.transform.localRotation = Quaternion.Euler(pitch, 0, 0);
    }

    private void OnDisable()
    {
        Camera.main.transform.SetParent(null);
    }

    void OnApplicationQuit()
    {
        Destroy(gameObject);
    }
}
