using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WikiGroupInfoVO
{
    public string WikiGroupName { get; set; }
    public string WikiGroupTittle { get; set; }
    public string WikiGroupImage { get; set; }
    public string WikiGroupDescription { get; set; }
    public WikiRecordsInfo Wiki_Records { get; set; }
    public WikiGroupInfoVO(string _wikiGroupName,string _wikiGroupTittle,string _wikiGroupImage,string _wikiGroupDescription, WikiRecordsInfo _wikiRecords)
    {
        WikiGroupName = _wikiGroupName;
        WikiGroupTittle = _wikiGroupTittle;
        WikiGroupImage = _wikiGroupImage;
        WikiGroupDescription = _wikiGroupDescription;
        Wiki_Records = _wikiRecords;
    }

}

public class WikiRecordsInfo
{
    public string WikiRecordName { get; set; }
    public string WikiRecordTittle { get; set; }
    public string WikiRecordImage { get; set; }
    public string WikiRecordDescription { get; set; }
}
