using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerControlle: MonoBehaviour
{
    #region Variables

    // Move Player
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private float speedMove;

    private CharacterController characterController;
    private float ySpeed = 0;

    #endregion


    #region Unity Functions

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {

    }

    #endregion

    #region Controller Function

    private void Move()
    {
        Vector2 moveInput = moveAction.action.ReadValue<Vector2>();

        Vector3 moveData = new Vector3(moveInput.x, 0, moveInput.y);

        moveData *= speedMove;

        if (characterController.isGrounded)
        {
            ySpeed = 0f;
        }
        else
        {
            ySpeed = ySpeed + (Physics.gravity.y * Time.deltaTime);
        }

        moveData.y = ySpeed;

        characterController.Move(moveData * Time.deltaTime);

    }
    #endregion
}