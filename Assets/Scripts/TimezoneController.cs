using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class TimezoneController : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdownTimezone;
    [SerializeField] private TextAsset timeZoneData;

    private List<string> timeZoneNames;

    private void Start()
    {
        LoadTimezoneData();
    }

    private void LoadTimezoneData()
    {
        string jsonText = timeZoneData.text;
        TimeZoneContainer data = JsonUtility.FromJson<TimeZoneContainer>("{\"timeZones\":" + jsonText + "}");

        timeZoneNames = new List<string>();

        if (data != null && data.timeZones != null)
        {
            foreach (TimeZoneData timeZone in data.timeZones)
            {
                timeZoneNames.Add(timeZone.text);
            }
        }

        PopulateDropdown();
    }

    private void PopulateDropdown()
    {
        dropdownTimezone.ClearOptions();
        dropdownTimezone.AddOptions(timeZoneNames);
    }
}