using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PersonMovementBase : MonoBehaviour
{
    public CharacterController characterController;
    public Transform cameraTransform; // 绑定主摄像机
    public float moveSpeed = 5f; // 角色移动速度
    public float jumpForce = 8f; // 跳跃力度
    public float gravity = 9.81f; // 重力
    protected Vector3 velocity;
    protected bool isGrounded;

    public abstract void HandleMovement();
}
