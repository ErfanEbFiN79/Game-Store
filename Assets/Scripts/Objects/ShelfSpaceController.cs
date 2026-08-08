using UnityEngine;

public class ShelfSpaceController : MonoBehaviour
{
    public StockInfoClass info;
    public int amountOnShelf;

    public void PlaceStocks(Stocks objectToPlace)
    {
        bool preventPlacing = true;
        if(amountOnShelf == 0)
        {
            info = objectToPlace.StockInfo;
            preventPlacing = false;

        }
        else
        {
            if (info.Name == objectToPlace.StockInfo.Name)
            {
                preventPlacing = false;
            }
        }

        if (!preventPlacing)
        {
            objectToPlace.transform.SetParent(transform);
            objectToPlace.MakePalace();
            amountOnShelf += 1;
        }

    }
}
