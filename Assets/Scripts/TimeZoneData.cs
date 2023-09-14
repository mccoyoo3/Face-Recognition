using System.Collections.Generic;

[System.Serializable]
public class TimeZoneData
{
    public string value;
    public string abbr;
    public int offset;
    public bool isdst;
    public string text;
    public List<string> utc;
}

[System.Serializable]
public class TimeZoneContainer
{
    public TimeZoneData[] timeZones;
}