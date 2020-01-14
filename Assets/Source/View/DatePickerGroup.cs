using System;
using System.Collections.Generic;
using UnityEngine;
public class DatePickerGroup : MonoBehaviour
{
    public DateTime m_minDate { get; set; }
    public DateTime m_maxDate { get; set; }
    public DateTime m_selectDate { get; set; }
    public List<DatePicker> m_datePickerList;
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
    public void OnDateUpdate()
    {
        m_selectTime = m_selectDate;
        for (int i = 0; i < m_datePickerList.Count; i++)
        {
            m_datePickerList[i].RefreshDateList();
        }
    }
}

