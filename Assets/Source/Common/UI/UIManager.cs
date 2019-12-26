using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager m_instance;

    private readonly Dictionary<string, UIFormBase> m_loadedForms = new Dictionary<string, UIFormBase>();
    private readonly Stack<string> m_openedForms = new Stack<string>();

    [SerializeField]
    private Transform m_UIContentRoot;
    [SerializeField]
    private Transform m_UIPopupRoot;

    private string m_currentFormName = "";
    private GameObject m_uiRoot;
    private ResourcesService m_resourcesService;
    
    public static UIManager instance { get { return m_instance; } }
    
    void Awake()
    {
        DontDestroyOnLoad(this);

        m_instance = this;

        DontDestroyOnLoad(this.gameObject);
        m_resourcesService = new ResourcesService();
    }

    public void ShowView(string _viewName)
    {
        m_loadedForms[m_currentFormName].ShowView(_viewName);
    }

    public void ShowLastOpenedForm()
    {
        if (m_openedForms.Count > 0)
        {
            m_loadedForms[m_currentFormName].Hide();
            m_currentFormName = m_openedForms.Pop();
            LoadForm(m_currentFormName);
            m_loadedForms[m_currentFormName].Show();
        }
    }

    public void ShowForm(string _formName, bool _isRoot)
    {
        LoadForm(_formName);

        if (m_loadedForms.ContainsKey(m_currentFormName))
        {
            m_openedForms.Push(m_currentFormName);
            m_loadedForms[m_currentFormName].Hide();
        }

        if (_isRoot)
        {
            m_openedForms.Clear();
        }

        m_currentFormName = _formName;
        m_loadedForms[m_currentFormName].Show();
    }
    
    private void LoadForm(string _formName)
    {
        if (!m_loadedForms.ContainsKey(_formName))
        {
            GameObject uiFormGO = m_resourcesService.Load<GameObject>(_formName);
            UIFormBase form = GameObject.Instantiate(uiFormGO).GetComponent<UIFormBase>();
            form.transform.SetParent(m_UIContentRoot);
            form.Anchor(0, 0, 0);

            m_loadedForms.Add(_formName, form);
        }
    }
}
