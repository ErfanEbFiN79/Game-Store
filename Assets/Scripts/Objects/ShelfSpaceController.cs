using System.Collections.Generic;
using UnityEngine;

public class ShelfSpaceController : MonoBehaviour
{
    [SerializeField] private List<Stocks> objectsOnShelf;
    [SerializeField] private List<Transform> bigXboxPoints;
    
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

                switch(info.type)
                {
                    case StockInfoClass.StockType.Pc:

                        break;

                    case StockInfoClass.StockType.PS:

                        break;

                    case StockInfoClass.StockType.Xbox:

                        break;

                    case StockInfoClass.StockType.GameThings:
                        
                        break;

                    case StockInfoClass.StockType.OtherThings:
                        
                        break;
                        
                }

                if(objectsOnShelf.Count >= bigXboxPoints.Count)
                {
                    preventPlacing = true;
                }
            }
        }

        if (!preventPlacing)
        {
            //objectToPlace.transform.SetParent(transform);
            objectToPlace.MakePalace();

            objectToPlace.transform.SetParent(bigXboxPoints[objectsOnShelf.Count]);

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
