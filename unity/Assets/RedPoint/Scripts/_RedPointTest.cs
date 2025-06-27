using UnityEngine;
using UnityEngine.UI;

public class _RedPointTest : MonoBehaviour
{
    [SerializeField]
    private RedPointTreeConfig config;

    [SerializeField] private Button btnSendNew;

    [SerializeField] private Button btnSendSystem;

    [SerializeField] private Button btnClear;
    
    void Awake()
    {
        RedPointManager.Init(config);
        
        //测试按钮
        btnSendNew.onClick.AddListener(() =>
        {
            Debug.Log("Mail.New");
            RedPointManager.Set("Mail.New", true);
        });
        
        btnSendSystem.onClick.AddListener(() =>
        {
            Debug.Log("Mail.System");
            RedPointManager.Set("Mail.System", true);
        });
        
        btnClear.onClick.AddListener(() =>
        {
            Debug.Log("Clear");
            RedPointManager.Set("Mail.New", false);
            RedPointManager.Set("Mail.System", false);
        });
        
        gameObject.SetActive(false);
        gameObject.SetActive(true);
    }
}