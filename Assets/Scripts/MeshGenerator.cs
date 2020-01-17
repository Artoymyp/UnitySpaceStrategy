using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MeshGenerator : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{
		// Create Vector2 vertices
		var vertices2D = new Vector2[] {
			new Vector2(0,0),
			new Vector2(0,1),
			new Vector2(1,1),
		};

		var vertices3D = System.Array.ConvertAll<Vector2, Vector3>(vertices2D, v => v);

		// Use the triangulator to get indices for creating triangles
		var indices = new int[]{0,1,2};

		// Generate a color for each vertex
		var colors = Enumerable.Range(0, vertices3D.Length)
			.Select(i => Random.ColorHSV())
			.ToArray();

		// Create the mesh
		var mesh = new Mesh
		{
			vertices = vertices3D,
			triangles = indices,
			colors = colors
		};

		mesh.RecalculateNormals();
		mesh.RecalculateBounds();

		// Set up game object with mesh;
		var meshRenderer = gameObject.AddComponent<MeshRenderer>();
		meshRenderer.material = new Material(Shader.Find("Sprites/Default"));

		var filter = gameObject.AddComponent<MeshFilter>();
		filter.mesh = mesh;
	}

	// Update is called once per frame
	void Update()
	{

	}
}
