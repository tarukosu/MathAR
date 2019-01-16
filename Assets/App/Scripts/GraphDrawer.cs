using System.Collections.Generic;
using UnityEngine;

namespace MathAR
{
    public enum Axis
    {
        X,
        Y
    }

    [RequireComponent(typeof(GraphRange))]
    public class GraphDrawer : MonoBehaviour
    {
        [SerializeField] private float interval = 1;

        protected FunctionOfTwoVariables function;
        protected GraphRange graphRange;

        void Awake()
        {
            function = GetComponent<FunctionOfTwoVariables>();
            graphRange = GetComponent<GraphRange>();
        }

        void Start()
        {

        }

        protected List<float> GetXGrid()
        {
            return GetGrid(graphRange.MinX, graphRange.MaxX);
        }

        protected List<float> GetYGrid()
        {
            return GetGrid(graphRange.MinY, graphRange.MaxY);
        }


        List<float> GetGrid(float min, float max)
        {
            var gridList = new List<float>();

            var intervalIndexMin = Mathf.CeilToInt(min / interval);
            var intervalIndexMax = Mathf.FloorToInt(max / interval);

            if (Mathf.Approximately(min, intervalIndexMin * interval))
            {
                intervalIndexMin++;
            }

            if (Mathf.Approximately(max, intervalIndexMax * interval))
            {
                intervalIndexMax--;
            }

            gridList.Add(min);
            for (var i = intervalIndexMin; i <= intervalIndexMax; i++)
            {
                gridList.Add(i * interval);
            }
            gridList.Add(max);

            return gridList;
        }
    }
}
