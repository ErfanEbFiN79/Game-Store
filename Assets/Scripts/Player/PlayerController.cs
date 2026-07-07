using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControlle: MonoBehaviour
{
    #region Variables

    // Move Player
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private float speedMove;

    #endregion


    #region Unity Functions

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
        Vector2 moveData = moveAction.action.ReadValue<Vector2>();
        transform.Translate(
            (moveData.x * speedMove) * Time.deltaTime,
            0,
            (moveData.y * speedMove) * Time.deltaTime
            );

    }

    private void Move2()
    {
        Vector2 moveData = moveAction.action.ReadValue<Vector2>();
        transform.position = transform.position + new Vector3(
            (moveData.x * speedMove) * Time.deltaTime,0,(moveData.y * speedMove) * Time.deltaTime);
    }

    #endregion
}
