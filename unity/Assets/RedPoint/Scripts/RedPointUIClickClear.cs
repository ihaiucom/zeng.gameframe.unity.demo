using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RedPointUIBinder))]
[RequireComponent(typeof(Button))]
public class RedPointUIClickClear : MonoBehaviour
{
    [SerializeField] private Button btn;
    [SerializeField] private RedPointUIBinder redPointUIBinder;


    void Start()
    {
        if (btn == null)
        {
            btn = GetComponent<Button>();
            redPointUIBinder = GetComponent<RedPointUIBinder>();
        }

        if (btn == null) return;
        if (redPointUIBinder == null) return;

        btn.onClick.AddListener(() => { RedPointManager.Set(redPointUIBinder.key, false); });
    }
}