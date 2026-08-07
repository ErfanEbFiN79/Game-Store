using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RowController : MonoBehaviour
{
    [SerializeField] private List<ScriptableObject> ListOfProducts;
    [SerializeField] private Transform[] poseForObjects;


    private void Update()
    {
        if(Mouse.current.middleButton.wasPressedThisFrame)
        {
            for (int i = 0; i < ListOfProducts.Count; i++)
            {
                print(ListOfProducts[i].name);
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        ListOfProducts.Add(other.transform.GetComponent<Stocks>().stockInfo);
        print("Add Object");
    }

    private void OnTriggerExit(Collider other)
    {
        ListOfProducts.Remove(other.transform.GetComponent<Stocks>().stockInfo);
        print("Remove Object");
    }
}
