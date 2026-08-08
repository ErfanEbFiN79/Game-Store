using UnityEngine;

[System.Serializable]
public class StockInfoClass
{
    public string Name;

    public enum StockType
    {
        Pc, PS, Xbox, PcGame, Ps5Game, XboxGame, GameThings, OtherThings
    }

    public StockType type;

}
