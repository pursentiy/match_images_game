using System;
using Figures;
using Figures.Animals;
using UnityEngine;

namespace Level.Params
{
    [Serializable]
    public class LevelFigureParams
    {
        public FigureAnimalTarget FigureAnimal;
        public FigureAnimalsMenu FigureMenu;
        public float Scale;
        public Color Color;
        public Vector3 Position;
    }
}