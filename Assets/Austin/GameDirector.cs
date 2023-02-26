using System;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class GameDirector : MonoBehaviour
{
    [SerializeField] private Slider globalismSlider;
    [SerializeField] private Slider urbanismSlider;
    [SerializeField] private Slider statismSlider;
    [SerializeField] private Slider innovationSlider;
    [SerializeField] private Slider marketsSlider;
    
    [SerializeField] private GameObject mainMenu;

    [SerializeField] private MockCityPlanner _cityPlanner;
    [SerializeField] private BuildingGenerator _buildingGenerator;
    [SerializeField] private PeopleGenerator _peopleGenerator;

    private List<GameObject> _objects;

    public void Start()
    {
        _objects = new List<GameObject>();
    }

    public void OnDone()
    {
        CityStats stats = new CityStats();
        stats.Globalism = globalismSlider.value;
        stats.Urbanism = urbanismSlider.value;
        stats.Statism = statismSlider.value;
        stats.Innovation = innovationSlider.value;
        stats.Markets = marketsSlider.value;

        mainMenu.SetActive(false);
        
        GameObject[] people = _peopleGenerator.GeneratePeople(stats);
        
        CityPlan cityPlan = _cityPlanner.GenerateCity(stats);
        for (int i = 0; i < cityPlan.BuildingRequirements.Length; i++)
        {
            GameObject buildingPrefab = _buildingGenerator.GenerateBuilding(stats, cityPlan.BuildingRequirements[i].Item2);
            GameObject building = Instantiate(buildingPrefab, cityPlan.BuildingRequirements[i].Item1);
            //building.transform.parent = transform;
            _objects.Add(building);
        }
        //GameObject road = Instantiate(cityPlan.Road, transform);
        //_objects.Add(road);
    }
}
