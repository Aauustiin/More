using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor;
using UnityEngine;

public abstract class HexType : MonoBehaviour
{
    public Vector2 Coords;
    public string Type;
    public abstract void GenerateHex();

    void start()
    {
        GenerateHex();
    }
}

public class HexGen : MonoBehaviour

{
    private HexType hextype;
    private List<int> HexList;

    public void hexlist(int Residential, int Industrial, int Commercial, int Infrastructure,
        int Entertainment, int Greenspace, int Nothing)
    {
        List<int> HexList = listgenerator(Residential, 0);
        HexList.AddRange(listgenerator(Industrial, 1));
        HexList.AddRange(listgenerator(Commercial, 2));
        HexList.AddRange(listgenerator(Infrastructure, 3));
        HexList.AddRange(listgenerator(Entertainment, 4));
        HexList.AddRange(listgenerator(Greenspace, 5));
        HexList.AddRange(listgenerator(Nothing, 6));
        this.HexList = HexList;
    }

    public HexType generator(Vector3 coords)
    {

        var Rnd = new System.Random();
        int HexIndex = Rnd.Next(HexList.Count);
        switch (HexList[HexIndex])
        {
            case 0:
                // code block
                break;
            case 1:
                // code block
                break;
            case 2:
                // code block
                break;
            case 3:
                // code block
                break;
            case 4:
                // code block
                break;
            case 5:
                // code block
                break;
            case 6:
                // code block
                break;

            default:
                // code block
                break;
        }
        
        return hextype;
    }

    private List<int> listgenerator(int size, int value)
    {
        List<int> l = new List<int>();
        for (int i = 0; i < size; i++)
        {
            l.Add(value);
        }

        return l;
    }
}

public class residential : HexType
{
    public void GenerateHex()
    {
        int i = new int();
        Debug.Log("implement this");
    }
}
public class industrial : HexType
{
    public void GenerateHex()
    {
        int i = 10;
        Debug.Log("implement this");
    }
}
public class Commercial : HexType
{
    public void GenerateHex()
    {
        int i = 10;
        Debug.Log("implement this");
    }
}
public class Infrastructure : HexType
{
    public void GenerateHex()
    {
        int i = 10;
        Debug.Log("implement this");
    }
}
public class Entertainment : HexType
{
    public void GenerateHex()
    {
        int i = 10;
        Debug.Log("implement this");
    }
}
public class Greenspace : HexType
{
    public void GenerateHex()
    {
        int i = 10;
        Debug.Log("implement this");
    }
}
public class Nothing : HexType
{
    public void GenerateHex()
    {
        int i = 10;
        Debug.Log("implement this");
    }
}

