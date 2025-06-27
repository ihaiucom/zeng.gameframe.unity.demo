using UnityEngine;

[RequireComponent(typeof(GameObject))]
public class RedPointUIBinder : MonoBehaviour
{
    public string key;
    public GameObject redDotObject;

    private void OnEnable()
    {
        RedPointManager.Register(key, UpdateState);
        redDotObject.SetActive(RedPointManager.IsActive(key));
    }

    private void OnDisable()
    {
        RedPointManager.Unregister(key, UpdateState);
    }

    private void UpdateState(bool isActive)
    {
        redDotObject.SetActive(isActive);
    }
}