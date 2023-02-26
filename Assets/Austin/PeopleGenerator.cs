using System.Collections.Generic;
using UnityEngine;

public class PeopleGenerator : MonoBehaviour, IPeopleGenerator
{
    private int _population = 10;
    [SerializeField] private GameObject personPrefab;
    [SerializeField] private Shader defaultShader;

    public GameObject[] GeneratePeople(CityStats stats)
    {
        GameObject[] people = new GameObject[_population];
        if (stats.Urbanism > 0.5)
        {
            for (int i = 0; i < (_population * stats.Urbanism); i++)
            {
                people[i] = Instantiate(personPrefab, transform);
            }
        }
        GenerateCharacterColours(stats, people);
        return people;
        
    }

    public void GenerateCharacterColours(CityStats stats, GameObject[] personObjects)
    {
        List<Color> characterColours = new List<Color> {};
        Color nativeColour = Random.ColorHSV();
        for (int i = 0; i < _population; i++)
        {
            if (stats.Globalism < Random.value)
            {
                MeshRenderer[] meshes = personObjects[i].GetComponentsInChildren<MeshRenderer>();
                Color color = Random.ColorHSV();
                Material mat = new Material(defaultShader);
                mat.SetColor("_Color", color);
                for (int j = 0; j < meshes.Length; j++)
                {
                    meshes[j].material = mat;
                }
            }
            else
            {
                MeshRenderer[] meshes = personObjects[i].GetComponentsInChildren<MeshRenderer>();
                Color color = Random.ColorHSV();
                Material mat = new Material(defaultShader);
                mat.SetColor("_Color", nativeColour);
                for (int j = 0; j < meshes.Length; j++)
                {
                    meshes[j].material = mat;
                }
            }
        }
    }
}
