﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

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
            m_loadedForms[m_currentFormName].Show();
        }
    }

    public void ShowForm(string _formName, bool _isRoot)
    {
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

        if (!m_loadedForms.ContainsKey(_formName))
        {
            LoadForm(_formName);
        }
        else
        {
            m_loadedForms[m_currentFormName].Show();
        }
    }
    
    private void LoadForm(string _formName)
    {
        //Addressables.LoadAssetAsync<GameObject>(_formName).Completed += OnFormLoaded;
        Addressables.InstantiateAsync(_formName).Completed += OnFormInstantiated;
    }

    /*
    private void OnFormLoaded(AsyncOperationHandle<GameObject> _obj)
    {
        UIFormBase form = Instantiate(_obj.Result).GetComponent<UIFormBase>();
        form.transform.SetParent(m_UIContentRoot);
        form.Anchor(0, 0, 0);

        form.Show();
        m_loadedForms.Add(form.formName, form);
    }
    */

    private void OnFormInstantiated(AsyncOperationHandle<GameObject> _obj)
    {
        UIFormBase form = _obj.Result.GetComponent<UIFormBase>();
        form.transform.SetParent(m_UIContentRoot);
        form.Anchor(0, 0, 0);

        form.Show();
        m_loadedForms.Add(form.formName, form);
    }
}
