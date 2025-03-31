using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public Transform playerBody; // ��ɫ����
    public Transform cameraBody;
    public float mouseSensitivity = 2f; // ���������

    private float pitch = 0f; // ��¼������ĸ�����

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

        // ��ɫˮƽ��ת
        playerBody.Rotate(Vector3.up * mouseX);

        // �������ֱ��ת�������ǣ�
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, -90f, 90f); // �����ӽǣ���ֹ��ת
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
