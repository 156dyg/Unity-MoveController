using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CameraPerson
{
    Third_Camera,
    First_Camera
}

public class CameraController : MonoBehaviour
{
    public ThirdPersonCamera ThirdCamera;
    public FirstPersonCamera FirstCamera;
    [Space(10)]
    public float duration = 0.5f;
    public float magnitude = 0.02f;

    private CameraPerson cameraPerson;

    private bool shaking = false;
    private Coroutine coroutine;
    // Start is called before the first frame update
    void Start()
    {
        // Òþ²Ø²¢Ëø¶¨Êó±ê
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        ToggleCamera(cameraPerson);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (shaking && coroutine != null) StopCoroutine(coroutine);
            shaking = true;

            coroutine = StartCoroutine(Shake(duration, magnitude));
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            cameraPerson = cameraPerson == CameraPerson.Third_Camera ? CameraPerson.First_Camera : CameraPerson.Third_Camera;
            ToggleCamera(cameraPerson);
        }
    }

    void ToggleCamera(CameraPerson cameraPerson)
    {
        ThirdCamera.enabled = cameraPerson == CameraPerson.Third_Camera;
        FirstCamera.enabled = cameraPerson == CameraPerson.First_Camera;

        switch (cameraPerson)
        {
            case CameraPerson.Third_Camera:
                ThirdCamera.Init();
                break;
            case CameraPerson.First_Camera:
                FirstCamera.Init();
                break;
        }

        PersonMoveController.Instance.SetHandleMovement(cameraPerson);
    }

    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPosition = Camera.main.transform.localPosition;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            Camera.main.transform.localPosition = Camera.main.transform.localPosition + new Vector3(x, y, 0);

            elapsed += Time.deltaTime;
            yield return null;
        }

        Camera.main.transform.localPosition = originalPosition;

        shaking = false;
    }

}
