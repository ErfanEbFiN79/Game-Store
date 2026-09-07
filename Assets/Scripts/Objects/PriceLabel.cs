using TMPro;
using UnityEngine;

public class PriceLabel : MonoBehaviour
{
    [SerializeField] private TMP_Text textOfPrice;

    public void SetPrice(float price)
    {
        textOfPrice.text = "$" + price;
    }

}
