using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Stocks : MonoBehaviour
{
    #region Variables
    public string code;
    [SerializeField] private float speed;
    [SerializeField] private float speedRotate;
    [SerializeField] private Collider col;

    private Quaternion firstRotate;
    private Rigidbody _rb;

    public StockInfoClass StockInfo;    
    public bool isPlaced;

    private float lastPrice;

    #endregion

    #region Unity Functions

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        firstRotate = transform.localRotation;
        StockInfo = StockInfoController.instance.GetInfo(stockName: StockInfo.Name);
        print(PlayerPrefs.GetFloat(code));
        if (PlayerPrefs.GetFloat(code) > 0)
        {
            ChangeInfo(PlayerPrefs.GetFloat(code));
        }
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
        //col.enabled = false;
    } 

    public void MakePalace()
    {
        _rb.isKinematic = true;
        isPlaced = true;
        col.enabled = false;
    }

    public void Release()
    {
        _rb.isKinematic = false;
        col.enabled = true;
    }

    #endregion

    public void ChangeInfo(float newPrice)
    {
        StockInfo.price = newPrice;
        PlayerPrefs.SetFloat(code, StockInfo.price);
    }
}