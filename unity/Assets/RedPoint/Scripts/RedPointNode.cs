using System;
using System.Collections.Generic;
using System.Linq;

public class RedPointNode
{
    public string Key { get; }
    public RedPointNode Parent { get; set; }
    public List<RedPointNode> children = new();
    
    private int rawCount = 0;
    public int TotalCount { get; private set; } = 0;

    public RedPointNode(string key,RedPointNode parent)
    {
        Key = key;
        Parent = parent;
    }

    public void SetCount(int count)
    {
        if (count < 0) count = 0;
        rawCount = count;
        UpdateTotalCount();
    }

    public int GetCount()
    {
        return TotalCount;
    }

    private void UpdateTotalCount()
    {
        int total = rawCount;
        foreach (var child in children)
        {
            total += child.TotalCount;
        }
        if (TotalCount != total)
        {
            TotalCount = total;
            Parent?.UpdateTotalCount();
            RedPointManager.NotifyStateChanged(this);
        }
    }
}