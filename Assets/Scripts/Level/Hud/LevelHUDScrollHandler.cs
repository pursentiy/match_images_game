﻿using UnityEngine;
using UnityEngine.EventSystems;

namespace Level.Hud
{
    public class LevelHudScrollHandler : MonoBehaviour
    {
        public void OnDrag(PointerEventData eventData)
        {
            
        }
        

        public void OnBeginDrag(PointerEventData eventData)
        {
            //Debug.Log($"Dragging Started in {this}");
        }

        public void OnEndDrag(PointerEventData eventData)
        {
           // Debug.Log($"Dragging Ended in {this}");
        }
    }
}