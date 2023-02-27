using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexGrid : MonoBehaviour
{
    [Header("Grid Settings")]
    public Vector2Int gridSize;

    [Header("Tile Settings")]
    public float outerSize = 1f;
    public float innerSize = 0f;
    public float height = 1f;
    public Material material;

    private void OnEnable()
    {
        LayoutGrid();
    }
    private void OnValidate()
    {
        if (Application.isPlaying)
        {
            LayoutGrid();
        }
    }

    private void LayoutGrid()
    {
        for (int y = 0; y < gridSize.y; y++)
        {
            for (int x = 0; x < gridSize.x; x++)
            {
                GameObject tile = new GameObject($"hex {x},{y}", typeof(HexRenderer));
                HexRenderer hexRenderer = tile.GetComponent<HexRenderer>();

                hexRenderer.outerSize = outerSize;
                hexRenderer.innerSize = innerSize;
                hexRenderer.height = height;
                hexRenderer.material=(material);
                hexRenderer.DrawMesh();
            }
        }
    }

    public Vector3 GetPositionForHexFromCoordinate(Vector2Int coordinate)
    {
        int column = coordinate.x;
        int row = coordinate.y;
        float width;
        float height;
        float xPosition;
        float yPosition;
        bool shouldOffset;
        float horizontalDistance;
        float verticalDistance;
        float offset;
        float size = outerSize;
        
        shouldOffset = (row % 2) == 0;
        width = Mathf.Sqrt(3) * size;
        height = 2f * size;
        horizontalDistance = width;
        verticalDistance = height * (3f / 4f);
        offset = (shouldOffset) ? width / 2 : 0;
        xPosition = (column * (horizontalDistance)) + offset;
        yPosition = (row * verticalDistance);
        return new Vector3(xPosition, 0, -yPosition);
    }
}
