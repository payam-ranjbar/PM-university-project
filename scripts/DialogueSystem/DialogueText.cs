using GameEventSystem;
using UnityEngine;

namespace DialogueSystem
{
    [System.Serializable]
    public class DialogueText
    {
        public string name;
        public string text;
        public AudioClip clip;
        public GameEvent dialogueEvent;
    }
}