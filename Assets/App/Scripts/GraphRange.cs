using System.Collections;
using System.Collections.Generic;
using MathAR;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SocialPlatforms;
using UnityEngine.Video;

namespace MathAR
{

    public class GraphRange : MonoBehaviour
    {
        [SerializeField] private float minX = -10;
        [SerializeField] private float maxX = 10;
        [SerializeField] private float minY = -10;
        [SerializeField] private float maxY = 10;

        public float MinX
        {
            set { minX = value; }
            get { return minX; }
        }

        public float MaxX
        {
            set { maxX = value; }
            get { return maxX; }
        }

        public float MinY
        {
            set { minY = value; }
            get { return minY; }
        }

        public float MaxY
        {
            set { maxY = value; }
            get { return maxY; }
        }
    }
}
