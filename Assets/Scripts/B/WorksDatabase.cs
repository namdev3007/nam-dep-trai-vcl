using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WorkDatabase", menuName = "ScriptableObjects/WorkDatabase")]
public class WorkDatabase : ScriptableObject
{
    public List<Works> works = new List<Works>();

    public int WorkCount
    {
        get { return works.Count; }
    }
}
