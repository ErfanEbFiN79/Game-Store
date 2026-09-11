using System.Collections.Generic;
using UnityEngine;

public class StockInfoController : MonoBehaviour
{
    public List<StockInfoClass> psInfo, xboxInfo, pcInfo, gameInfo, otherInfo;
    private List<StockInfoClass> allStocks = new List<StockInfoClass>();

    public static StockInfoController instance;


    private void Awake()
    {
        instance = this;

        allStocks.AddRange(psInfo);
        allStocks.AddRange(xboxInfo);
        allStocks.AddRange(pcInfo);
        allStocks.AddRange(gameInfo);
        allStocks.AddRange(otherInfo);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public StockInfoClass GetInfo(string stockName)
    {
        StockInfoClass infoToReturn = null;


        foreach (var item in allStocks)
        {
            if (item.Name == stockName)
            {
                infoToReturn = item; 
            }
        }

        return infoToReturn;

    }
}
