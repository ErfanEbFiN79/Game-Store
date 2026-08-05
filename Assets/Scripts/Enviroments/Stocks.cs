using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Stocks : MonoBehaviour
{
    #region Variables

    [SerializeField] private float speed;
    [SerializeField] private float speedRotate;
    public ScriptableObject stockInfo;

    private Quaternion firstRotate;
    private Rigidbody _rb;
    private bool isPlaced;

    #endregion

    #region Unity Functions

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        firstRotate = transform.localRotation;
    }

    private void Update()
    {
        if(isPlaced)
        {
            transform.localPosition = 
                Vector3.MoveTowards(transform.localPosition, Vector3.zero, speed * Time.deltaTime);

            // if we think we need to change rotation also we can do this
            //transform.localRotation =
                //Quaternion.Slerp(transform.localRotation,firstRotate, speedRotate * Time.deltaTime);
        }
    }

    #endregion


    #region Access Functions

    public void PickUp()
    {
        _rb.isKinematic = true;
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;

        isPlaced = false;
    } 

    public void MakePalace()
    {
        _rb.isKinematic = true;
        isPlaced = true;
    }

    public void Release()
    {
        _rb.isKinematic = false;
    }

    #endregion
}