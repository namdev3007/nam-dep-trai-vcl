using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PhoneDatabase", menuName = "ScriptableObjects/PhoneDatabase")]
public class PhoneDatabase : ScriptableObject
{
    public List<Phones> phones = new List<Phones>();

    public int PhoneCount
    {
        get { return phones.Count; }
    }
}
