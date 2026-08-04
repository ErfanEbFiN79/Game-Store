using UnityEngine;

[CreateAssetMenu(fileName = "StockInfo", menuName = "Scriptable Objects/StockInfo")]
public class StockInfo : ScriptableObject
{
    public string name;
    public enum StockType
    {
        Pc, PS5, Xbox, PcGame, Ps5Game, XboxGame, OtherThings
    }

    public StockType type;
}
