using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeDatabase : MonoBehaviour
{
    public List<Cakes> cakes = new List<Cakes>();

    public int CakeCount
    {
        get { return cakes.Count; }
    }

    public void AddCake(Cakes cake)
    {
        cakes.Add(cake);
    }

    public void RemoveCake(Cakes cake)
    {
        if (cakes.Contains(cake))
        {
            cakes.Remove(cake);
        }
    }

    public Cakes GetCake(int index)
    {
        if (index >= 0 && index < cakes.Count)
        {
            return cakes[index];
        }
        return null;
    }
}
