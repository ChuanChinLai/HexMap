using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexGridChunk : MonoBehaviour
{

    HexCell[] cells;

    Canvas m_Canvas;
    HexMesh m_HexMesh;


    void Awake()
    {
        m_Canvas = GetComponentInChildren<Canvas>();
        m_HexMesh = GetComponentInChildren<HexMesh>();

        cells = new HexCell[HexMetrics.chunkSizeX * HexMetrics.chunkSizeZ];
    }

    void Start()
    {
        //m_HexMesh.Triangulate(cells);
    }

    // Update is called once per frame
    void Update ()
    {
		
	}

    void LateUpdate()
    {
        m_HexMesh.Triangulate(cells);
        enabled = false;
    }

    public void AddCell(int index, HexCell cell)
    {
        cells[index] = cell;
        cell.chunk = this;
        cell.transform.SetParent(transform, false);
        cell.uiRect.SetParent(m_Canvas.transform, false);
    }

    public void Refresh()
    {
        //m_HexMesh.Triangulate(cells);
        enabled = true;
    }
}
