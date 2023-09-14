using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadEditor : MonoBehaviour
{
    public MeshFilter mesh;
    public float x;
    public float y;
    public float z;

    // Start is called before the first frame update
    void Start()
    {
        //CreateTriangleMesh();
        //CenterPivot();
    }

    private void CenterPivot()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        Mesh mesh = meshFilter.mesh;

        // Get the center of the mesh
        Vector3[] vertices = mesh.vertices;
        Vector3 center = Vector3.zero;
        for (int i = 0; i < vertices.Length; i++)
        {
            center += vertices[i];
        }
        center /= vertices.Length;

        // Calculate the offset needed to move the center to the origin
        Vector3 pivotOffset = -center;

        // Move the vertices to center the pivot
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] += pivotOffset;
        }

        // Assign the updated vertices to the mesh
        mesh.vertices = vertices;
        mesh.RecalculateBounds();
    }

    private void CreateTriangleMesh()
    {
        // Create a new mesh
        Mesh mesh = new Mesh();

        // Define vertices of the triangle
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(0f, 0f, 0f), // Bottom-left
            new Vector3(1f, 0f, 0f), // Bottom-right
            new Vector3(x, y, z) // Top-middle
        };

        // Define triangles (one triangle)
        int[] triangles = new int[]
        {
            0, 2, 1 // Clockwise order of vertices
        };

        // Calculate normals (not required for a flat surface like a triangle)
        Vector3[] normals = new Vector3[]
        {
            -Vector3.forward,
            -Vector3.forward,
            -Vector3.forward
        };

        // Define UVs to map materials/textures (optional)
        Vector2[] uvs = new Vector2[]
        {
            new Vector2(0f, 0f),
            new Vector2(1f, 0f),
            new Vector2(0.5f, 1f)
        };

        // Assign the data to the mesh
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.normals = normals;
        mesh.uv = uvs;

        // Get the MeshFilter component and assign the mesh
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        meshFilter.mesh = mesh;
    }
}
