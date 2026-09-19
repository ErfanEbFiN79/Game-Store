using TMPro;
using UnityEngine;

public class OSV1 : MonoBehaviour
{

    public TMP_Text nameText;
    public TMP_Text priceText;


    #region Show and change price
    private void ShowInfo(Stocks stock)
    {
        StockInfoClass stockInfo = stock.StockInfo;
        nameText.text = stockInfo.Name;
        priceText.text = stockInfo.price.ToString();
    }

    private void ResetPanel()
    {
        nameText.text = "Please put a product first";
        priceText.text = 00.00 + "$";
    }

    #endregion

    #region Unity

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("STK"))
        {
            ShowInfo(other.GetComponent<Stocks>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("STK"))
        {
            ResetPanel();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("STK"))
        {
            ResetPanel() ;
        }
    }

    #endregion
}