using System;
using Figures;
using Figures.Animals;

namespace Storage.FigureByTypes
{
    [Serializable]
    public class FigureByTypeParams
    {
        public FigureType FigureType;
        public FiguresByType FiguresByType;
    }

    [Serializable]
    public class FiguresByType
    {
        public FigureAnimalTarget FigureAnimal;
        public FigureAnimalsMenu FigureMenu;
    }
}