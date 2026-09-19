using UnityEngine;
using UnityEngine.InputSystem;

public class CameraSwitchSystem : MonoBehaviour
{
    [Header("Input Refrences")]
    [SerializeField] private InputActionReference intract;
    [SerializeField] private PlayerControlle playerCode;

    public GameObject activeCamera;
    public GameObject cameraTarget;
    public GameObject[] objectsNeedWork;

    [SerializeField] private bool inSide;

    private void Update()
    {
        if (inSide)
        {
            if (intract.action.WasPerformedThisFrame())
            {
                activeCamera.SetActive(false);
                cameraTarget.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                foreach (var item in objectsNeedWork)
                {
                    item.SetActive(false);
                }
            }
        }
    }

    public void SetReset()
    {
        foreach (var item in objectsNeedWork)
        {
            item.SetActive(true);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inSide = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inSide = false;
        }
    }

    #region Buttons

    public void CloseWithCam()
    {
        activeCamera.SetActive(true);
        cameraTarget.SetActive(false);
        SetReset();
        Cursor.lockState = CursorLockMode.Locked;
    }

    #endregion

}
