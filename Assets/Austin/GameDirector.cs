using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Vector2 = UnityEngine.Vector2;

public class GameDirector : MonoBehaviour
{
    [SerializeField] private Slider globalismSlider;
    [SerializeField] private Slider urbanismSlider;
    [SerializeField] private Slider statismSlider;
    [SerializeField] private Slider innovationSlider;
    [SerializeField] private Slider marketsSlider;
    
    [SerializeField] private GameObject mainMenu;

    [SerializeField] private MockCityPlanner cityPlanner;
    [SerializeField] private BuildingGenerator buildingGenerator;
    [SerializeField] private PeopleGenerator peopleGenerator;
    [SerializeField] private GenerateSpeech speechGenerator;

    [SerializeField] private Vector2 minBound;
    [SerializeField] private Vector2 maxBound;

    [SerializeField] private GameObject thoughtBubble;
    [SerializeField] private Camera mainCamera;
    
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
        
        GameObject[] people = peopleGenerator.GeneratePeople(stats);
        string[] thoughts = speechGenerator.GenerateThoughts(stats, people.Length);
        for (int i = 0; i < people.Length; i++)
        {
            people[i].transform.position = new UnityEngine.Vector3(UnityEngine.Random.Range(minBound.x, maxBound.x), 0.5f,UnityEngine.Random.Range(minBound.y, maxBound.y));
            people[i].transform.rotation = UnityEngine.Quaternion.Euler(0f, UnityEngine.Random.Range(0f, 360f), 0f);
            GameObject thought = Instantiate(thoughtBubble, people[i].transform);
            thought.transform.GetChild(0).GetChild(0).position = mainCamera.WorldToScreenPoint(people[i].transform.position + new UnityEngine.Vector3(0, 0f, 1));
            thought.GetComponentInChildren<TextMeshProUGUI>().text = thoughts[i];
        }

        CityPlan cityPlan = cityPlanner.GenerateCity(stats);
        for (int i = 0; i < cityPlan.BuildingRequirements.Length; i++)
        {
            GameObject buildingPrefab = buildingGenerator.GenerateBuilding(stats, cityPlan.BuildingRequirements[i].Item2);
            GameObject building = Instantiate(buildingPrefab, cityPlan.BuildingRequirements[i].Item1);
            building.transform.localScale = new UnityEngine.Vector3(5f, 5f, 5f);
            building.transform.position = new UnityEngine.Vector3(UnityEngine.Random.Range(minBound.x, maxBound.x), 0.5f,UnityEngine.Random.Range(minBound.y, maxBound.y));
            building.transform.rotation = UnityEngine.Quaternion.Euler(0f, UnityEngine.Random.Range(0f, 360f), 0f);
            //building.transform.parent = transform;
            //_objects.Add(building);
        }
        //GameObject road = Instantiate(cityPlan.Road, transform);
        //_objects.Add(road)
    }

    private void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out RaycastHit hit)) {
            Transform objectHit = hit.transform;
            
            // Do something with the object that was hit by the raycast.
        }
    }
}
