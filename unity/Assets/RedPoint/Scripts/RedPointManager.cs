using System;
using System.Collections.Generic;

public class RedPointManager
{
    private static Dictionary<string, RedPointNode> _nodeDict = new();

    public static void Init(RedPointTreeConfig config)
    {
        _nodeDict.Clear();
        foreach (var root in config.rootNodes)
        {
            BuildNodeRecursive(null, root);
        }
    }

    private static void BuildNodeRecursive(RedPointNode parent, RedPointNodeData data)
    {
        var node = new RedPointNode(data.key);
        node.Parent = parent;
        _nodeDict[data.key] = node;
        parent?.AddChild(node);

        if (data.children != null)
        {
            foreach (var child in data.children)
                BuildNodeRecursive(node, child);
        }
    }

    public static void Set(string key, bool active)
    {
        if (_nodeDict.TryGetValue(key, out var node))
        {
            node.SetActive(active);
        }
    }

    public static bool IsActive(string key)
    {
        return _nodeDict.TryGetValue(key, out var node) && node.IsActive;
    }

    public static void Register(string key, Action<bool> onChange)
    {
        if (_nodeDict.TryGetValue(key, out var node))
            node.OnStateChanged += onChange;
    }

    public static void Unregister(string key, Action<bool> onChange)
    {
        if (_nodeDict.TryGetValue(key, out var node))
            node.OnStateChanged -= onChange;
    }
}