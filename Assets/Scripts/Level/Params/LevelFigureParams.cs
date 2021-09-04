using System;
using Figures;
using UnityEngine;

namespace Level.Params
{
    [Serializable]
    public class LevelFigureParams
    {
        public Figure Figure;
        public float Scale;
        public Color Color;
        public Vector3 Position;
    }
}