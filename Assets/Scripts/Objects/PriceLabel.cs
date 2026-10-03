using TMPro;
using UnityEngine;

public class PriceLabel : MonoBehaviour
{
    [SerializeField] private TMP_Text textOfPrice;
    public Stocks ObjectOn;

    public void SetPrice(float price, Stocks objOn)
    {
        textOfPrice.text = "$" + price;
        ObjectOn = objOn;
    }

    public void GetLastInfo()
    {
        if (ObjectOn != null)
        {
            textOfPrice.text = "$" + ObjectOn.StockInfo.price;
        }

    }

}
