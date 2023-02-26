using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Face
{
	Pubic List<Vector3> vertices { get; private set;}
	pubic List<int> triangles { get; private set;}
	pubic List<Vector2> uvs { get; private set;}
	public Face(List <Vector3> vertices, List<int> triangles, List <Vector2> uvs)
	{
		this.vertices = vertices;
		this.triangles =	triangles;
		this.uvs = uvs;
	}
	

}

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class HexRenderer: monoBehaviour
{
	private Mesh m_mesh;
	private MeshFilter m_meshFilter;
	private MeshRenderer m_meshRenderer;
	private List<faces> m_faces;

	public Material material;
	private void Awake()
	{
		m_meshFilter = GetComponent<MeshFilter>();
		m_meshRenderer = GetComponent<MeshRenderer>();
		m_mesh = new Mesh();
		m_mesh.name = "hex";

		m_meshFilter.mesh = m_mesh;
		m_meshRenderer.material = material;
	}

	private void private void OnEnable() {
		{
			DrawMesh();
		}
	}
	private void DrawFaces()
	{

	}
	public void OnValidate()
	{
		if (Application.isPlaying)
		{
			DrawMesh();
		}
	}


private void CombineFaces()
{
	List <Vector3> vertices = new List<Vector3>();
	List <int> trianges = new List<int>();
	List <Vector2> vuvs = new List<Vector2>();

	for (int i =0; i< m_faces[i].triangles)
	{
		//add vertices
		vertices.AddRange(m_faces[i].vertices);
		uvs.AddRange(m_faces[i].uvs);
		//offset triangles
		int offset = 4*i;
		foreach (int triangle in m_faces[i].triangles)
		{
			tris.Add(triangle + offset);
		}
	}

	m_mesh.vertices = vertices.ToArray();
	m_mesh.triangles = tris.ToArray();
	m_mesh.uv = uvs.ToArray();
	m_mesh.RecalculateNormals();
}

}

