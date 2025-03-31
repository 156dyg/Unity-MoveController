using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonMoveController : MonoBehaviour
{
    private static PersonMoveController instance;
    public static PersonMoveController Instance { get { return instance; } }

    public FirstPersonMovement firstPersonMovement;
    public ThirdPersonMovement thirdPersonMovement;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        HandleMovement();

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            firstPersonMovement.moveSpeed *= 2;
            thirdPersonMovement.moveSpeed *= 2;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            firstPersonMovement.moveSpeed /= 2;
            thirdPersonMovement.moveSpeed /= 2;
        }
    }

    private void HandleMovement()
    {
        if (firstPersonMovement.enabled) firstPersonMovement.HandleMovement();
        if (thirdPersonMovement.enabled) thirdPersonMovement.HandleMovement();
    }

    public void SetHandleMovement(CameraPerson cameraType)
    {
        firstPersonMovement.enabled = cameraType == CameraPerson.First_Camera;
        thirdPersonMovement.enabled = cameraType == CameraPerson.Third_Camera;
    }
}
