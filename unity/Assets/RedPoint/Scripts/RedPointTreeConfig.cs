using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "RedPoint/RedPointTreeConfig")]
public class RedPointTreeConfig : ScriptableObject
{
    public List<RedPointNodeData> rootNodes;
}

[Serializable]
public class RedPointNodeData
{
    public string key;
    public List<RedPointNodeData> children;
}