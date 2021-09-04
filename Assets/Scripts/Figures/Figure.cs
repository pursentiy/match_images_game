using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

namespace Figures
{
    public abstract class Figure : MonoBehaviour, IFigure
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private FigureType _figureType;
        [SerializeField] private Transform _transform;
        [SerializeField] private PolygonCollider2D _collider;
        public bool IsCompleted { get; private set; }
        public bool IsTarget { get; }
        public int FigureScale { get; }
        public Color FigureColor { get; }
        
        public FigureType FigureType { get;  }

        public void SetFigureCompleted(bool value)
        {
            IsCompleted = value;
        }

        public void SetFigureColor()
        {
            if (_spriteRenderer == null)
            {
                Debug.LogWarning($"Sprite Renderer is missing in {this}");
                return;
            }

            _spriteRenderer.color = FigureColor;
        }

        protected Figure(Color figureColor, bool isTarget)
        {
            FigureColor = figureColor;
            IsTarget = isTarget;
        }
    }
}
