using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class HexMesh : MonoBehaviour
{
    Mesh m_HexMesh;
    MeshCollider m_MeshCollider;

    List<Vector3> vertices;
    List<Color> colors;
    List<int> triangles;

    void Awake()
    {
        //GetComponent<Renderer>().material.color = Color.white;
        GetComponent<MeshFilter>().mesh = m_HexMesh = new Mesh();
        m_HexMesh.name = "Hex Mesh";

        m_MeshCollider = gameObject.AddComponent<MeshCollider>();

        vertices = new List<Vector3>();
        colors = new List<Color>();
        triangles = new List<int>();
    }

    public void Triangulate(HexCell[] cells)
    {
        m_HexMesh.Clear();
        vertices.Clear();
        colors.Clear();
        triangles.Clear();

        for (int i = 0; i < cells.Length; i++)
        {
            Triangulate(cells[i]);
        }

        m_HexMesh.vertices = vertices.ToArray();
        m_HexMesh.colors = colors.ToArray();
        m_HexMesh.triangles = triangles.ToArray();
        m_HexMesh.RecalculateNormals();

        m_MeshCollider.sharedMesh = m_HexMesh;
    }

    void Triangulate(HexCell cell)
    {
        Vector3 center = cell.transform.localPosition;

        for (int i = 0; i < 6; i++)
        {
            AddTriangle(center, center + HexMetrics.corners[i], center + HexMetrics.corners[i + 1]);
            AddTriangleColor(cell.color);
        }
    }

    void AddTriangle(Vector3 v1, Vector3 v2, Vector3 v3)
    {
        int vertexIndex = vertices.Count;
        vertices.Add(v1);
        vertices.Add(v2);
        vertices.Add(v3);
        triangles.Add(vertexIndex);
        triangles.Add(vertexIndex + 1);
        triangles.Add(vertexIndex + 2);
    }


    void AddTriangleColor(Color color)
    {
        colors.Add(color);
        colors.Add(color);
        colors.Add(color);
    }
}
