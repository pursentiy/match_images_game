using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

namespace Figures
{
    public abstract class Figure : MonoBehaviour, IFigure
    {
        [SerializeField] protected SpriteRenderer _spriteRenderer;
        [SerializeField] private FigureType _figureType;
        [SerializeField] protected Transform _transform;
        [SerializeField] private PolygonCollider2D _collider;
        public bool IsCompleted { get; private set; }
        public bool IsTarget { get; private set;}
        public int FigureScale { get; private set;}
        public Color FigureColor { get; private set;}
        
        public FigureType FigureType { get; }

        public void SetFigureCompleted(bool value)
        {
            IsCompleted = value;
        }

        protected void SetFigureColor()
        {
            if (_spriteRenderer == null)
            {
                Debug.LogWarning($"Sprite Renderer is missing in {this}");
                return;
            }

            _spriteRenderer.color = FigureColor;
        }

        protected void SetUpFigure(Color figureColor, bool isTarget)
        {
            FigureColor = figureColor;
            IsTarget = isTarget;
        }
    }
}
