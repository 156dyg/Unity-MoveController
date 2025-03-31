using UnityEngine;

public class ThirdPersonMovement : PersonMovementBase
{

    public float rotationSpeed = 10f; // ��ת�ٶ�

    public override void HandleMovement()
    {
        // ����Ƿ��ڵ�����
        isGrounded = characterController.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        // ��Ծ
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * 2f * gravity);
        }


        // ��ȡ���루WASD �� ��ҡ�ˣ�
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;
        // ��������
        velocity.y -= gravity * Time.deltaTime;

        if (direction.magnitude >= 0.1f)
        {
            // �����������
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            float angle = Mathf.LerpAngle(characterController.transform.eulerAngles.y, targetAngle, Time.deltaTime * rotationSpeed);

            // ��ת��ɫ�����ƶ�����
            characterController.transform.rotation = Quaternion.Euler(0, angle, 0);

            // ���������ƶ�����
            Vector3 moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            characterController.Move(velocity * Time.deltaTime + moveDir.normalized * moveSpeed * Time.deltaTime);
            return;
        }

        characterController.Move(velocity * Time.deltaTime);
    }
}
