using System.Collections.Generic;
using UnityEngine;

public class ShelfSpaceController : MonoBehaviour
{
    [SerializeField] private List<Stocks> objectsOnShelf;
    
    public StockInfoClass info;
    public int amountOnShelf;
    

    public void PlaceStocks(Stocks objectToPlace)
    {
        bool preventPlacing = true;
        if(objectsOnShelf.Count == 0)
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
            //amountOnShelf += 1;
            objectsOnShelf.Add(objectToPlace);
        }

    }

    public Stocks GetStock()
    {
        Stocks objectForReturn = null;

        if (objectsOnShelf.Count > 0)
        {
            objectForReturn = objectsOnShelf[objectsOnShelf.Count - 1];

            objectsOnShelf.RemoveAt(objectsOnShelf.Count - 1);
        }


        return objectForReturn;
    }
}
