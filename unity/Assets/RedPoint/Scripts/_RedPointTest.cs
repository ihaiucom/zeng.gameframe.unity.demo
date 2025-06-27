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
            RedPointManager.SetCount("Mail.New", RedPointManager.GetCount("Mail.New") + 1);
        });
        
        btnSendSystem.onClick.AddListener(() =>
        {
            Debug.Log("Mail.System");
            RedPointManager.SetCount("Mail.System", RedPointManager.GetCount("Mail.New") + 1);
        });
        
        btnClear.onClick.AddListener(() =>
        {
            Debug.Log("Clear");
            RedPointManager.SetCount("Mail.New", 0);
            RedPointManager.SetCount("Mail.System", 0);
        });
        
        gameObject.SetActive(false);
        gameObject.SetActive(true);
    }
}