using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerControlle: MonoBehaviour
{
    #region Variables

    // Move Player
    [Header("Input Refrences")]
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private InputActionReference jumpAction;
    [SerializeField] private InputActionReference lookAction;

    [Header("Tools Need")]
    [SerializeField] private Camera cam;

    [Header("Setting")]
    [SerializeField] private float speedMove;
    [SerializeField] private float jumpPower;
    [SerializeField] private float lookSpeed;
    [SerializeField] private float numberlook;

    [Header("Pickup system")]
    [SerializeField] private LayerMask stockMask;
    [SerializeField] private float workRange;
    [SerializeField] private Transform holdPoint;   
    private GameObject pickObject;

    private CharacterController characterController;
    private float ySpeed = 0;
    private float hRoot, vRoot;

    #endregion


    #region Unity Functions

    private void Start()
    {
        characterController = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
    }


    private void Update()
    {
        MoveAndJump();
        Look();
        CheckStock();
    }

    #endregion

    #region Controller Function

    private void MoveAndJump()
    {
        Vector2 moveInput = moveAction.action.ReadValue<Vector2>();

        //Vector3 moveData = new Vector3(moveInput.x, 0, moveInput.y);

        Vector3 vMove = transform.forward * moveInput.y;
        Vector3 hMove = transform.right * moveInput.x;

        Vector3 moveData = hMove + vMove;
        moveData = moveData.normalized;

        moveData *= speedMove;

        if (characterController.isGrounded)
        {
            ySpeed = 0f;
            if (jumpAction.action.WasPerformedThisFrame())
            {
                ySpeed = jumpPower;
            }
        }
        else
        {
            ySpeed = ySpeed + (Physics.gravity.y * Time.deltaTime);
        }

        moveData.y = ySpeed;

        characterController.Move(moveData * Time.deltaTime);

    }

    private void Look()
    {
        Vector2 lookData = lookAction.action.ReadValue<Vector2>();

        hRoot += lookData.x * lookSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0f, hRoot, 0f);

        vRoot -= lookData.y * lookSpeed * Time.deltaTime;
        vRoot = Math.Clamp(vRoot,-numberlook,numberlook);
        cam.transform.localRotation = Quaternion.Euler(vRoot,0f, 0f);
    }

    #endregion

    #region Check

    private void CheckStock()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
            if(Physics.Raycast(ray, out hit, workRange, stockMask))
            {
                print("Let's get it");
                pickObject = hit.collider.gameObject;
                pickObject.transform.SetParent(holdPoint);
                pickObject.transform.localPosition = Vector3.zero;
                pickObject.transform.localRotation = Quaternion.identity;
            }
        }

    }

    #endregion
}