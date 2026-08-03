using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Stocks : MonoBehaviour
{
    #region Variables

    private Rigidbody _rb;

    #endregion

    #region Unity Functions

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    #endregion


    #region Access Functions

    public void PickUp()
    {
        _rb.isKinematic = true;
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    } 

    public void MakePalace()
    {
        _rb.isKinematic = true;
    }

    #endregion
}