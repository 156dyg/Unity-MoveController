using UnityEngine;

public class ThirdPersonMovement : PersonMovementBase
{

    public float rotationSpeed = 10f; // 旋转速度

    public override void HandleMovement()
    {
        // 检测是否在地面上
        isGrounded = characterController.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        // 跳跃
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * 2f * gravity);
        }


        // 获取输入（WASD 或 左摇杆）
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;
        // 重力作用
        velocity.y -= gravity * Time.deltaTime;

        if (direction.magnitude >= 0.1f)
        {
            // 计算相机方向
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            float angle = Mathf.LerpAngle(characterController.transform.eulerAngles.y, targetAngle, Time.deltaTime * rotationSpeed);

            // 旋转角色面向移动方向
            characterController.transform.rotation = Quaternion.Euler(0, angle, 0);

            // 计算最终移动方向
            Vector3 moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            characterController.Move(velocity * Time.deltaTime + moveDir.normalized * moveSpeed * Time.deltaTime);
            return;
        }

        characterController.Move(velocity * Time.deltaTime);
    }
}
