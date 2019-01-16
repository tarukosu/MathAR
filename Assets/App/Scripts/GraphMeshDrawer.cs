using UnityEngine;
using UnityEngine.Rendering;

namespace MathAR
{
    public class GraphMeshDrawer : GraphDrawer
    {
        [SerializeField] private Material material;

        void Start()
        {
            CreateMesh();
        }

        void CreateMesh()
        {
            var gridListX = GetXGrid();
            var gridListY = GetYGrid();

            var verticesCount = gridListX.Count * gridListY.Count * 2;
            var vertices = new Vector3[verticesCount];

            for (var j = 0; j < gridListY.Count; j++)
            {
                var y = gridListY[j];

                for (var i = 0; i < gridListX.Count; i++)
                {
                    var x = gridListX[i];
                    var value = function.Calc(x, y);
                    var upperVertex = new Vector3(x, value + float.Epsilon, y);
                    var lowerVertex = new Vector3(x, value - float.Epsilon, y);

                    vertices[(i + j * gridListX.Count) * 2] = upperVertex;
                    vertices[(i + j * gridListX.Count) * 2 + 1] = lowerVertex;

                    //Debug.Log("v" + vertex);
                }
            }

            var trianglesCount = (gridListX.Count -1) * (gridListY.Count-1) * 12;
            var triangles = new int[trianglesCount];

            for (var j = 0; j < gridListY.Count-1; j++)
            {
                for (var i = 0; i < gridListX.Count - 1; i++)
                {
                    var u0 = (i + j * gridListX.Count) * 2;
                    var u1 = u0 + 2;
                    var u2 = u0 + gridListX.Count * 2;
                    var u3 = u2 + 2;

                    var offset = (i + j * (gridListX.Count - 1)) * 12;

                    triangles[offset] = u0;
                    triangles[offset + 1] = u3;
                    triangles[offset + 2] = u1;

                    triangles[offset + 3] = u0;
                    triangles[offset + 4] = u2;
                    triangles[offset + 5] = u3;


                    triangles[offset + 6] = u0 + 1;
                    triangles[offset + 7] = u1 + 1;
                    triangles[offset + 8] = u3 + 1;

                    triangles[offset + 9] = u0 + 1;
                    triangles[offset + 10] = u3 + 1;
                    triangles[offset + 11] = u2 + 1;
                }
            }

            var mesh = new Mesh();
            mesh.indexFormat = IndexFormat.UInt32;
            mesh.vertices = vertices;
            mesh.triangles = triangles;

            /*
            {
                vertices = vertices,
                triangles = triangles,
                //indexFormat = IndexFormat.UInt32
            };
            */
            
            mesh.RecalculateNormals();

            var meshFilter = gameObject.GetComponent<MeshFilter>();
            if (!meshFilter)
            {
                meshFilter = gameObject.AddComponent<MeshFilter>();
            }

            //meshFilter.mesh = mesh;
            meshFilter.sharedMesh = mesh;

            var meshRenderer = gameObject.GetComponent<MeshRenderer>();
            if (!meshRenderer)
            {
                meshRenderer = gameObject.AddComponent<MeshRenderer>();
            }
            meshRenderer.material = material;

            var meshCollider = gameObject.GetComponent<MeshCollider>();
            if (!meshCollider)
            {
                meshCollider = gameObject.AddComponent<MeshCollider>();
            }

            meshCollider.sharedMesh = mesh;

        }
    }
}
