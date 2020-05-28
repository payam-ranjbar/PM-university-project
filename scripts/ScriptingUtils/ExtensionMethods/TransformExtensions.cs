using System;
using UnityEngine;

namespace ScriptingUtils.ExtensionMethods
{
    public static class TransformExtensions
    {
        public static void FlipX(this Transform transform, int direction)
        {
            
            var localScale = transform.localScale;
            if (Math.Sign(localScale.x) != Math.Sign(direction))
            {
                localScale = new Vector3(-localScale.x, localScale.y, localScale.z);
                transform.localScale = localScale;
            }
 
        }
    }
}