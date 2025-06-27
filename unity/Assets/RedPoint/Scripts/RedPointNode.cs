using System;
using System.Collections.Generic;
using System.Linq;

public class RedPointNode
{
    public string Key { get; }
    public bool IsActive { get; private set; }
    public RedPointNode Parent { get; set; }
    private readonly List<RedPointNode> _children = new();

    public event Action<bool> OnStateChanged;

    public RedPointNode(string key)
    {
        Key = key;
    }

    public void AddChild(RedPointNode child) => _children.Add(child);

    public void SetActive(bool active)
    {
        if (IsActive == active) return;
        IsActive = active;
        OnStateChanged?.Invoke(IsActive);
        Parent?.RefreshFromChildren();
    }

    public void RefreshFromChildren()
    {
        bool anyChildActive = _children.Any(child => child.IsActive);
        if (IsActive == anyChildActive) return;

        IsActive = anyChildActive;
        OnStateChanged?.Invoke(IsActive);
        Parent?.RefreshFromChildren();
    }
}