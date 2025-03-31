using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Camera Camera;
    public Transform Item;
    //�����Ŀ��֮��ľ���
    [Range(1.5f, 10f)]
    public float Dis = 5f;
    public float rotationSpeed = 500f;
    public float ScrollWheelSpeed = 500f;

    //���������Ʒ�Χ
    public float MaxYaw = 60;
    public float MinYaw = -30;

    private float yaw = 0f;
    private float pitch = 0f;

    public void Init()
    {
        if (Item != null)
        {
            yaw = Item.eulerAngles.y;
            pitch = Item.eulerAngles.x;
        }
    }

    void Update()
    {
        Rotate();
        Move();
        Scale();
    }

    void Scale()
    {
        if (Item == null || Camera == null) return;
        float p = Input.GetAxis("Mouse ScrollWheel");
        if (p == 0) return;

        Dis -= p * Time.deltaTime * ScrollWheelSpeed;
        Dis = Mathf.Clamp(Dis, 1.5f, 10);
        // ������ת����
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);

        Vector3 offset = rotation * new Vector3(0, 0, -Dis);
        Vector3 movePos = Vector3.Lerp(Item.position + offset, Camera.transform.position, Time.deltaTime*10);
        Camera.transform.position = movePos;
    }

    void Move()
    {
        if (Item == null || Camera == null) return;
        // ������ת����
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        Vector3 offset = rotation * new Vector3(0, 0, -Dis);

        Vector3 movePos = Vector3.Lerp(Item.position + offset, Camera.transform.position, Time.deltaTime * 10);
        // �������λ��
        Camera.transform.position = movePos;
    }

    void Rotate()
    {
        if (Item == null || Camera == null) return;
        // ��ȡ�������
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        float mouseY = -Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

        yaw += mouseX;
        pitch = Mathf.Clamp(pitch + mouseY, MinYaw, MaxYaw); // ���Ƹ�����

        // ������ת����
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        Camera.transform.rotation = rotation;
    }

    void OnApplicationQuit()
    {
        Destroy(gameObject);
    }
}
