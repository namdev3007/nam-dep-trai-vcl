using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CustomerDatabase", menuName = "ScriptableObjects/CustomerDatabase")]
public class CustomerDatabase : ScriptableObject
{
    public List<Customers> customers = new List<Customers>();

    public int CustomerCount
    {
        get { return customers.Count; }
    }
}