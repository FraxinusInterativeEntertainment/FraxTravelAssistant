using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public abstract class UIFormBase : MonoBehaviour
{
    [SerializeField]
    protected string m_formName;
    public string formName { get { return m_formName; } }
    [SerializeField]
    protected List<ViewInfo> m_uiViewInfos;
    
    protected readonly Dictionary<string, UIViewBase> m_loadedViews = new Dictionary<string, UIViewBase>();
    protected readonly Stack<UIViewBase> m_viewStack = new Stack<UIViewBase>();

    protected virtual void Start()
    {
        InitForm();
    }

    public virtual void Show()
    {
        this.gameObject.SetActive(true);
    }

    public virtual void Hide()
    {
        this.gameObject.SetActive(false);
    }

    public virtual void ShowView(string _uiViewName)
    {
        if (!m_loadedViews.ContainsKey(_uiViewName))
        {
            
        }
        else
        {
            m_loadedViews[_uiViewName].Show();
            m_viewStack.Push(m_loadedViews[_uiViewName]);
        }
    }

    public virtual void HideTopView()
    {
        if (m_viewStack.Count > 0)
        {
            m_viewStack.Pop().Hide();
        }
    }

    public virtual void Anchor(float _x, float _y, float _z)
    {
        this.transform.localPosition = new Vector3(_x, _y, _z);
    }

    /*
    protected virtual void LoadView(string _uiViewName)
    {
        ResourcesService resourcesService = new ResourcesService();
        GameObject viewGO = resourcesService.Load<GameObject>(_uiViewName);

        Addressables.InstantiateAsync(_uiViewName).Completed += OnViewInstantiated;

    }
    */

    protected virtual void InitForm()
    {
        foreach (ViewInfo viewInfo in m_uiViewInfos)
        {
            if (viewInfo.layer == UIViewLayer.Background)
            {
                viewInfo.uiView.InstantiateAsync().Completed += OnBackGroundViewInstantiated;
            }
            else if (viewInfo.layer == UIViewLayer.Content)
            {
                viewInfo.uiView.InstantiateAsync().Completed += OnContentViewInstantiated;
            }
        }
    }

    protected virtual void OnBackGroundViewInstantiated(AsyncOperationHandle<GameObject> _obj)
    {
        UIViewBase uiView = _obj.Result.GetComponent<UIViewBase>();
        uiView.transform.SetParent(this.transform);
        uiView.transform.SetAsFirstSibling();
        uiView.Anchor(0, 0, 0);
    }

    protected virtual void OnContentViewInstantiated(AsyncOperationHandle<GameObject> _obj)
    {
        UIViewBase uiView = _obj.Result.GetComponent<UIViewBase>();
        uiView.transform.SetParent(this.transform);
        uiView.Anchor(0, 0, 0);
    }
}

[System.Serializable]
public class ViewInfo
{
    [SerializeField]
    private AssetReference m_uiView;
    public AssetReference uiView { get { return m_uiView; } }
    [SerializeField]
    private UIViewLayer m_layer;
    public UIViewLayer layer { get { return m_layer; } }
}

public enum UIViewLayer
{ 
    Background,
    Content
}