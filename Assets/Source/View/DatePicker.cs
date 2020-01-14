using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public delegate void OnDateUpdate();

public enum DateType
{
    Year, Month, Day
}
/// <summary>
/// 日期选择器
/// </summary>
public class DatePicker : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
   [SerializeField]
    private DateType m_dateType;
   [SerializeField]
    private int m_itemNum = 3;
    [HideInInspector]
    /// <summary>
    /// 更新选择的目标值
    /// </summary>
    private float m_updateLength = 0.0f;
    /// <summary>
    /// 子节点预制体
    /// </summary>
    [SerializeField]
    private GameObject m_itemObj;
    /// <summary>
    /// 子节点容器对象
    /// </summary>
    [SerializeField]
    private Transform m_itemParent;
    /// <summary>
    /// 我属于的日期选择组
    /// </summary>
    [HideInInspector]
    public DatePickerGroup m_myGroup;
    /// <summary>
    /// 当选择日期的委托事件
    /// </summary>
    public event OnDateUpdate _onDateUpdate;
    void Awake()
    {
        m_itemObj.SetActive(false);
        m_updateLength = m_itemObj.GetComponent<RectTransform>().sizeDelta.y;
    }

    /// <summary>
    /// 初始化时间选择器
    /// </summary>
    public void Init()
    {
        for (int i = 0; i < m_itemNum; i++)
        {
            //计算真实位置
            int m_real_i = -(m_itemNum / 2) + i;
            SpawnItem(m_real_i);
        }
        RefreshDateList();
    }
    /// <summary>
    /// 生成子对象
    /// </summary>
    /// <param name="dataNum">对应日期</param>
    /// <param name="real_i">真实位置</param>
    /// <returns></returns>
    GameObject SpawnItem(float _real_i)
    {
        GameObject m_item = Instantiate(m_itemObj);
        m_item.SetActive(true);
        m_item.transform.SetParent(m_itemParent);
        m_item.transform.localScale = new Vector3(1, 1, 1);
        m_item.transform.localEulerAngles = Vector3.zero;
        if (_real_i != 0)
        {
            m_item.GetComponent<Text>().color = new Color(1, 1, 1, 1 - 0.2f - (Mathf.Abs(_real_i) / (m_itemNum / 2 + 1)));
        }
        return m_item;
    }

    Vector3 oldDragPos;
    /// <summary>
    /// 当开始拖拽
    /// </summary>
    /// <param name="eventData"></param>
    /// 

    public void OnBeginDrag(PointerEventData eventData)
    {
        oldDragPos = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("拖拽");
        UpdateSelectDate(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        m_itemParent.localPosition = Vector3.zero;
    }

    /// <summary>
    /// 更新选择的时间
    /// </summary>
    /// <param name="eventData"></param>
    void UpdateSelectDate(PointerEventData eventData)
    {
        //判断拖拽的长度是否大于目标值
        if (Mathf.Abs(eventData.position.y - oldDragPos.y) >= m_updateLength)
        {
            int num;
            //判断加减
            if (eventData.position.y > oldDragPos.y)
            {
                //+
                num = 1;
            }
            else
            {
                //-
                num = -1;
            }
            DateTime m_data = new DateTime();
            switch (m_dateType)
            {
                case DateType.Year:
                    m_data = m_myGroup.m_selectDate.AddYears(num);
                    break;
                case DateType.Month:
                    m_data = m_myGroup.m_selectDate.AddMonths(num);
                    break;
                case DateType.Day:
                    m_data = m_myGroup.m_selectDate.AddDays(num);
                    break;
            }
            //判断是否属于时间段
            if (IsInDate(m_data, m_myGroup.m_minDate, m_myGroup.m_maxDate))
            {
                m_myGroup.m_selectDate = m_data;
                oldDragPos = eventData.position;
                _onDateUpdate();
            }
            //   m_itemParent.localPosition = Vector3.zero;
        }
        else
        {
            //m_itemParent.localPosition = new Vector3(0, (eventData.position.y - oldDragPos.y), 0);
        }
    }

    /// <summary>
    /// 刷新时间列表
    /// </summary>
    public void RefreshDateList()
    {
        DateTime m_data = new DateTime();
        for (int i = 0; i < m_itemNum; i++)
        {
            //计算真实位置
            int m_real_i = -(m_itemNum / 2) + i;
            switch (m_dateType)
            {
                case DateType.Year:
                    m_data = m_myGroup.m_selectDate.AddYears(m_real_i);
                    break;
                case DateType.Month:
                    m_data = m_myGroup.m_selectDate.AddMonths(m_real_i);
                    break;
                case DateType.Day:
                    m_data = m_myGroup.m_selectDate.AddDays(m_real_i);
                    break;
          
            }
            string str = "";
            if (IsInDate(m_data, m_myGroup.m_minDate, m_myGroup.m_maxDate))
            {
                switch (m_dateType)
                {
                    case DateType.Year:
                        str = m_data.Year.ToString();
                        break;
                    case DateType.Month:
                        str = m_data.Month.ToString();
                        break;
                    case DateType.Day:
                        str = m_data.Day.ToString();
                        break;
                 
                }
            }
            m_itemParent.GetChild(i).GetComponent<Text>().text = str;
        }

    }
    /// <summary> 
    /// 判断某个日期是否在某段日期范围内，返回布尔值
    /// </summary> 
    /// <param name="dt">要判断的日期</param> 
    /// <param name="dt_min">开始日期</param> 
    /// <param name="dt_max">结束日期</param> 
    /// <returns></returns>  
    public bool IsInDate(DateTime dt, DateTime dt_min, DateTime dt_max)
    {
        return dt.CompareTo(dt_min) >= 0 && dt.CompareTo(dt_max) <= 0;
    }
}

