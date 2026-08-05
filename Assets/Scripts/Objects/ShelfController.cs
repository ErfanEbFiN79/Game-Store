using UnityEngine;

public class ShelfController : MonoBehaviour
{
    #region Variables

    [SerializeField] private ScriptableObject stocks;

    [SerializeField] private int amountOnShelf;

    [SerializeField] private GameObject[] Rows;

    #endregion

    #region Unity Funtion

    public void Update()
    {

    }

    #endregion

    #region Controller

    public void AddStock(ScriptableObject getStock)
    {
        print(getStock.name);
    }

    #endregion

    #region Send Info

    public bool WeHaveSpace()
    {
        return true;
    }

    #endregion
}
