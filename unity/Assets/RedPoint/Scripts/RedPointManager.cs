using System;
using System.Collections.Generic;

public class RedPointManager
{
    private static Dictionary<string, RedPointNode> _nodeDict = new();
    private static Dictionary<string, List<Action<int>>> bindings = new(); 
    public static void Init(RedPointTreeConfig config)
    {
        _nodeDict.Clear();
        bindings.Clear();
        foreach (var root in config.rootNodes)
        {
            var node = BuildNodeRecursive(root, null);
            _nodeDict[node.Key] = node;
        }
    }
    private static RedPointNode BuildNodeRecursive(RedPointNodeData data, RedPointNode parent)
    {
        var node = new RedPointNode(data.key,parent);
        foreach (var childData in data.children)
        {
            var childNode = BuildNodeRecursive(childData, node);
            node.children.Add(childNode);
            _nodeDict[childNode.Key] = childNode;
        }
        return node;
    }
    
    public static void SetCount(string key, int count)
    {
        if (_nodeDict.TryGetValue(key, out var node))
        {
            node.SetCount(count);
        }
    }
    
    public static void SubCount(string key, int val)
    {
        int num = GetCount(key);
        SetCount(key, num - val);
    }

    public static int GetCount(string key)
    {
        if (_nodeDict.TryGetValue(key, out var node))
        {
            return node.GetCount();
        }
        return 0;
    }

    public static bool IsActive(string key)
    {
        return GetCount(key) > 0;
    }
    
    public static void Register(string key, Action<int> onChange)
    {
        if (!bindings.TryGetValue(key, out var list))
        {
            list = new List<Action<int>>();
            bindings[key] = list;
        }
        if (!list.Contains(onChange))
            list.Add(onChange);
        
        
        if (_nodeDict.TryGetValue(key, out var node))
            onChange?.Invoke(node.GetCount());
    }

    public static void Unregister(string key, Action<int> onChange)
    {
        if (bindings.TryGetValue(key, out var list))
        {
            list.Remove(onChange);
        }
    }
    
    public static void NotifyStateChanged(RedPointNode node)
    {
        if (bindings.TryGetValue(node.Key, out var list))
        {
            foreach (var cb in list)
            {
                cb?.Invoke(node.GetCount());
            }
        }
    }
}