using System;
using System.Collections.Generic;
using System.Linq;
using Figures.Animals;
using Plugins.FSignal;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Level.Hud.Click
{
    public class ClickHandler : MonoBehaviour, IClickHandler
    {
        public FSignal<FigureAnimalsMenu> StartGrabbingPositionSignal { get; } = new FSignal<FigureAnimalsMenu>();

        public FSignal<FigureAnimalTarget> ReleaseGrabbingPositionSignal { get; } = new FSignal<FigureAnimalTarget>();
        
        private bool _isDragging;
        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            if (_isDragging)
            {
                TryDetectGrabRelease();
                return;
            }
            
            TryDetectGrab();
        }

        private void TryDetectGrab()
        {
            if (!Input.GetMouseButtonDown(0))
            {
                return;
            }
            
            var figure = TryGetFigureAnimalMenuOnDragStart(Input.mousePosition);
            _isDragging = true;
            //StartGrabbingPositionSignal.Dispatch(figure);
        }

        private void TryDetectGrabRelease()
        {
            if (!Input.GetMouseButtonUp(0))
            {
                return;
            }

            var figure = TryGetFigureAnimalTargetOnDragEnd(Input.mousePosition);
            
            //ReleaseGrabbingPositionSignal.Dispatch(figure);
            _isDragging = false;
        }
        
        private FigureAnimalsMenu TryGetFigureAnimalMenuOnDragStart(Vector2 position)
        {
            var pointerData = new PointerEventData(EventSystem.current);
            var resultsData = new List<RaycastResult>();
            pointerData.position = position;
            EventSystem.current.RaycastAll(pointerData, resultsData);;

            var raycastResult = resultsData.FirstOrDefault(result => result.gameObject.GetComponent<FigureAnimalsMenu>() != null);
            return raycastResult.gameObject == null ? null : raycastResult.gameObject.GetComponent<FigureAnimalsMenu>();
        }
        
        private FigureAnimalTarget TryGetFigureAnimalTargetOnDragEnd(Vector2 position)
        {
            var resultsData =  Physics2D.Raycast(_camera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            
            if (resultsData.collider == null)
            {
                return null;
            }
            
            var raycastResult = resultsData.transform.gameObject.GetComponent<FigureAnimalTarget>();
            return raycastResult.gameObject == null ? null : raycastResult.gameObject.GetComponent<FigureAnimalTarget>();
        }
    }
}