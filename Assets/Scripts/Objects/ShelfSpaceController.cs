using System.Collections.Generic;
using UnityEngine;

public class ShelfSpaceController : MonoBehaviour
{
    [SerializeField] private List<Stocks> objectsOnShelf;
    [SerializeField] private List<Transform> bigXboxPoints;
    [SerializeField] private List<Transform> bigPs5Points;
    [SerializeField] private List<Transform> bigPcPoints;
    [SerializeField] private List<Transform> gameThingsPoints;
    [SerializeField] private List<Transform> otherThingsPoints;

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
            info = objectToPlace.StockInfo;
            if (info.Name == objectToPlace.StockInfo.Name)
            {
                preventPlacing = false;

                switch(info.type)
                {
                    case StockInfoClass.StockType.Pc:

                        if (objectsOnShelf.Count >= bigPcPoints.Count)
                        {
                            preventPlacing = true;
                        }

                        break;

                    case StockInfoClass.StockType.PS:

                        if (objectsOnShelf.Count >= bigPs5Points.Count)
                        {
                            preventPlacing = true;
                        }

                        break;

                    case StockInfoClass.StockType.Xbox:

                        if (objectsOnShelf.Count >= bigXboxPoints.Count)
                        {
                            preventPlacing = true;
                        }

                        break;

                    case StockInfoClass.StockType.GameThings:

                        if (objectsOnShelf.Count >= gameThingsPoints.Count)
                        { 
                            preventPlacing = true;
                        }

                        break;

                    case StockInfoClass.StockType.OtherThings:

                        if (objectsOnShelf.Count >= otherThingsPoints.Count)
                        {
                            preventPlacing = true;
                        }

                        break;
                        
                }


            }
        }

        if (!preventPlacing)
        {
            //objectToPlace.transform.SetParent(transform);
            objectToPlace.MakePalace();

            switch (info.type)
            {
                case StockInfoClass.StockType.Pc:

                    objectToPlace.transform.SetParent(bigPcPoints[objectsOnShelf.Count]);

                    break;

                case StockInfoClass.StockType.PS:

                    objectToPlace.transform.SetParent(bigPs5Points[objectsOnShelf.Count]);

                    break;

                case StockInfoClass.StockType.Xbox:

                    objectToPlace.transform.SetParent(bigXboxPoints[objectsOnShelf.Count]);

                    break;

                case StockInfoClass.StockType.GameThings:

                    objectToPlace.transform.SetParent(gameThingsPoints[objectsOnShelf.Count]);

                    break;

                case StockInfoClass.StockType.OtherThings:

                    objectToPlace.transform.SetParent(otherThingsPoints[objectsOnShelf.Count]);

                    break;

            }


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
