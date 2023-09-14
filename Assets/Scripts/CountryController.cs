using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class CountryController : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdownCountry;
    [SerializeField] private TextAsset countryData;

    private List<string> countryNames;

    private void Start()
    {
        LoadCountryData();
    }

    private void LoadCountryData()
    {
        string jsonText = countryData.text;
        CountryData data = JsonUtility.FromJson<CountryData>("{\"countries\":" + jsonText + "}");

        countryNames = new List<string>();

        if (data != null && data.countries != null)
        {
            foreach (Country country in data.countries)
            {
                countryNames.Add(country.name);
            }
        }

        PopulateDropdown();
    }

    private void PopulateDropdown()
    {
        dropdownCountry.ClearOptions();
        dropdownCountry.AddOptions(countryNames);
    }
}