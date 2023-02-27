using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HexType : MonoBehaviour
{
    public Vector2 Coords;
    public string Type;
    public abstract void GenerateHex();
    void Update()
    {
        
    }
}

public class hex : MonoBehaviour
                  {
                      public float residential;
    public float industrial;
    public float commercial;
    public float Infrastructure;
    public float Entertainment;
    public float greenspace;
    public float nothing;
    private HexType hextype;

    private HexType generator(float Residential, float Industrial, float Commercial, float Infrastructure,
        float Entertainment, float greenspace, float nothing)
    {
        return hextype;
    }


    void start()
    {}
}
