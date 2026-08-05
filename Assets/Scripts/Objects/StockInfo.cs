using UnityEngine;

[CreateAssetMenu(fileName = "StockInfo", menuName = "Scriptable Objects/StockInfo")]
public class StockInfo : ScriptableObject
{
    public string name;
    public enum StockType
    {
        Pc, PS, Xbox, PcGame, Ps5Game, XboxGame, GameThings ,OtherThings
    }

    public StockType type;
}
