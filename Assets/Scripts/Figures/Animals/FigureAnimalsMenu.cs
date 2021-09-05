using System;
using System.Net.Sockets;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Figures.Animals
{
    public class FigureAnimalsMenu : Figure, IFigureAnimalsMenu
    {
        [SerializeField] protected Image _image;
        [SerializeField] protected RectTransform _transform;
        
        private Sequence _fadeAnimationSequence;

        public void SetUpFigure(Color color)
        {
            _image.color = color;
        }

        public void SetScale(float scale)
        {
            _transform.localScale = new Vector3(scale, scale, 0);
        }

        private void FadeFigure()
        {
            var color = _image.color;
            
            _fadeAnimationSequence = DOTween.Sequence().Append(_image.DOColor(new Color(color.r, color.g, color.b, 0.5f), 0.2f));
        }

        public void SetConnected()
        {
            FadeFigure();
            SetFigureCompleted(true);
        }

        private void OnDestroy()
        {
            _fadeAnimationSequence?.Kill();
        }
    }
}