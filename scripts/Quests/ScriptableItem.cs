using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Items
{
    public class ScriptableItem : ScriptableObject
    {

        public string Name;
        public string Game;
        public float ChanceOfAppear;
        public int CardHP;
        public int RepairCost;

        public void Repair()
        {

        }

        public void Affect()
        {

        }

        public void PublishToServer()
        {

        }
        
        public virtual string ShowDetails()
        {
            return null;
        }

    }
} 

