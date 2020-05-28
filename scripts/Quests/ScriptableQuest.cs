using System.Collections;
using System.Collections.Generic;
using GameEventSystem;
using Items;
using UnityEngine;

namespace Quests
{
    public abstract class ScriptableQuest : ScriptableObject
    {
    
        public int progression = 0;

        public int Progression => progression;

        public GameEvent StartEvent;
        public GameEvent ProgressionEvent;
        public GameEvent CompletionEvent;
//        public bool IsFinished { get; private set; }
        public bool IsFinished;
        public string Title;
        public string Description;
        public int CompletionSteps;
        public List<ScriptableItem> RewardsOnComplete;

        public abstract void OnStart();

        public abstract void OnComplete();
        
        public abstract void OnProgress();

        public void Start()
        {
            progression = 0;
            IsFinished = false;
            OnStart();
            StartEvent.Raise();
            
            StartEvent.Raise();
            
        }
        public void Finish()
        {
            IsFinished = true;
            OnComplete();
            
            
        }

        public void Progress()
        {
            if (progression < CompletionSteps)
            {
                progression++;
                OnProgress();

                ProgressionEvent.Raise();

                if (progression == CompletionSteps)
                {
                    //                Finish();
                    IsFinished = true;
                    CompletionEvent.Raise();
                }
            }
            else
            {

            }
        }     
    }



}
