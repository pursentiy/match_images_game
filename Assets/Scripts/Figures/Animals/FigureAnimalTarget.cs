using DG.Tweening;
using UnityEngine;

namespace Figures.Animals
{
    public class FigureAnimalTarget : Figure, IFigureAnimalTarget
    {
        [SerializeField] protected SpriteRenderer _spriteRenderer;
        [SerializeField] protected Transform _transform;
        
        public void SetUpFigure(Color color, float scale, Vector3 position)
        {
            _spriteRenderer.color = color;
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

            _spriteRenderer.DOColor(FigureColor, 0.3f);
        }
        
        public void SetConnected()
        {
            SetFigureColor();
            SetFigureCompleted(true);
        }
    }
}