using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 日期选择组
/// </summary>
public class DatePickerGroup : MonoBehaviour
{
    public DateTime m_minDate { get; set; }
    public DateTime m_maxDate { get; set; }
    public DateTime m_selectDate { get; set; }
    /// <summary>
    /// 时间选择器列表
    /// </summary>
    public List<DatePicker> m_datePickerList;
    /// <summary>
    /// 当选择日期的委托事件
    /// </summary>
    public event OnDateUpdate m_OnDateUpdate;

    public static DateTime m_selectTime;
    void Awake()
    {
        m_minDate = new DateTime(1950, 1, 1);
        m_maxDate = new DateTime(2050, 1, 1);
        Init();
    }
    public void Init(DateTime _dt)
    {
        m_selectDate = _dt;
        for (int i = 0; i < m_datePickerList.Count; i++)
        {
            m_datePickerList[i].m_myGroup = this;
            m_datePickerList[i].Init();
            m_datePickerList[i]._onDateUpdate += OnDateUpdate;
        }
    }
    public void Init()
    {
        m_selectDate = DateTime.Now;
        for (int i = 0; i < m_datePickerList.Count; i++)
        {
            m_datePickerList[i].m_myGroup = this;
            m_datePickerList[i].Init();
            m_datePickerList[i]._onDateUpdate += OnDateUpdate;
        }
    }

    /// <summary>
    /// 当选择的日期更新
    /// </summary>
    public void OnDateUpdate()
    {
        //Debug.Log("当前选择日期：" + _selectDate.ToString("yyyy年MM月dd日"));
        //将选中的时间传入到创建任务脚本中
        //CreateNewTask.ChoiceTime = _selectDate;
        m_selectTime = m_selectDate;
        for (int i = 0; i < m_datePickerList.Count; i++)
        {
            m_datePickerList[i].RefreshDateList();
        }
    }
}

