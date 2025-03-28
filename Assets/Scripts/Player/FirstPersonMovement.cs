using UnityEngine;

public class FirstPersonMovement : PersonMovementBase
{
    public override void HandleMovement()
    {
        isGrounded = characterController.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = characterController.transform.right * moveX + characterController.transform.forward * moveZ;
        characterController.Move(velocity * Time.deltaTime + move * moveSpeed * Time.deltaTime);

        // ��Ծ
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * 2f * gravity);
        }

        // ����Ӱ��
        velocity.y -= gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

}
