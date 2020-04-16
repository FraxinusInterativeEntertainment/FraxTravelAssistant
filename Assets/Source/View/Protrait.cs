using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Protrait : MonoBehaviour
{
    [SerializeField]
    private Button m_protraitButton;
    void Start()
    {
        m_protraitButton.onClick.AddListener(OnClickChangeIcon);
    }
    private void OnClickChangeIcon()
    {

    }
}
