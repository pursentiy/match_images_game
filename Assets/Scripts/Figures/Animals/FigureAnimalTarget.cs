using UnityEngine;

namespace Figures.Animals
{
    public class FigureAnimalTarget : Figure, IFigureAnimalTarget
    {
        [SerializeField] protected SpriteRenderer _spriteRenderer;
        [SerializeField] protected Transform _transform;
        [SerializeField] private PolygonCollider2D _collider;
        
        public void SetUpFigure(float scale, Vector3 position)
        {
            _transform.localScale = new Vector3(scale, scale, 0);
            _transform.position = position;
        }

        private void SetFigureColor()
        {
            if (_spriteRenderer == null)
            {
                Debug.LogWarning($"Sprite Renderer is missing in {this}");
                return;
            }

            _spriteRenderer.color = FigureColor;
        }
        
        public void SetConnected()
        {
            SetFigureColor();
            SetConnected();
        }
    }
}