﻿using UnityEngine;
using UnityEngine.Events;

namespace GameEventSystem
{
    public class GameEventListener : MonoBehaviour
    {
        public GameEvent[] Events;
        public UnityEvent Response;

        private void OnEnable()
        {
            foreach(GameEvent e in Events)
            {
                e.RegisterListener(this);
            }
        }

        public void OnEventsRaised()
        {
            Response.Invoke();
        }
    }
}