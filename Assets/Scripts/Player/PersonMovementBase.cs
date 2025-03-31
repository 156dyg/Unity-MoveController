using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PersonMovementBase : MonoBehaviour
{
    public CharacterController characterController;
    public Transform cameraTransform; // ���������
    public float moveSpeed = 5f; // ��ɫ�ƶ��ٶ�
    public float jumpForce = 8f; // ��Ծ����
    public float gravity = 9.81f; // ����
    protected Vector3 velocity;
    protected bool isGrounded;

    public abstract void HandleMovement();
}
