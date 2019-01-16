using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace MathAR
{
    public class GraphLineDrawer : GraphDrawer
    {
        [SerializeField] private float lineWidth = 0.01f;
        [SerializeField] private Material material;
        [SerializeField] private Gradient ColorX;
        [SerializeField] private Gradient ColorY;

        private List<LineRenderer> lineRenderers = new List<LineRenderer>();

        void Start()
        {
            CreateLines();
        }

        void CreateLine(string lineName, Vector3[] positions, Gradient colorGradient)
        {
            var line = new GameObject(lineName);
            line.transform.SetParent(transform);
            var lineRenderer = line.AddComponent<LineRenderer>();
            lineRenderer.useWorldSpace = false;
            lineRenderer.positionCount = positions.Length;
            lineRenderer.colorGradient = colorGradient;
            lineRenderer.startWidth = lineWidth;
            lineRenderer.endWidth = lineWidth;
            lineRenderer.material = material;
            lineRenderer.SetPositions(positions);
        }

        void CreateLines()
        {
            var gridListX = GetXGrid();
            var gridListY = GetYGrid();

            foreach (var y in gridListY)
            {
                var positions = new List<Vector3>();
                foreach (var x in gridListX)
                {
                    var value = function.Calc(x, y);
                    var position = new Vector3(x, value, y);
                    positions.Add(position);
                }
                CreateLine($"Line Y={y}", positions.ToArray(), ColorY);
            }

            foreach (var x in gridListX)
            {
                var positions = new List<Vector3>();
                foreach (var y in gridListY)
                {
                    var value = function.Calc(x, y);
                    var position = new Vector3(x, value, y);
                    positions.Add(position);
                }

                CreateLine($"Line X={x}", positions.ToArray(), ColorX);
            }
        }
    }
}
