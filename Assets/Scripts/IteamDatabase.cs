using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IteamDatabase", menuName = "ScriptableObjects/IteamDatabase")]
public class IteamDatabase : ScriptableObject
{
    public List<Iteams> iteams = new List<Iteams>();

    public int IteamCount
    {
        get { return iteams.Count; }
    }
}
