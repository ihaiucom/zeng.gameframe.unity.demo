using TMPro;
using UnityEngine;

[RequireComponent(typeof(GameObject))]
public class RedPointUIBinder : MonoBehaviour
{
    public string key;
    public GameObject redDotObject;
    public TextMeshProUGUI numText;

    private void OnEnable()
    {
        if (numText == null) numText = redDotObject.GetComponentInChildren<TextMeshProUGUI>();
        RedPointManager.Register(key, UpdateState);
        UpdateState(RedPointManager.GetCount(key));
    }

    private void OnDisable()
    {
        RedPointManager.Unregister(key, UpdateState);
    }

    private void UpdateState(int num)
    {
        redDotObject.SetActive(num > 0);
        if (numText != null)
        {
            numText.text = num.ToString();
        }
    }
}