using GameEventSystem;
using UnityEngine;

namespace DialogueSystem
{
    public class Dialogue : ScriptableObject
    {
        public DialogueText[] lines;
        public GameEvent endOfDialogueEvent;
    }
} 