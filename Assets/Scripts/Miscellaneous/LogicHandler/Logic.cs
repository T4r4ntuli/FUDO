using UnityEngine;

namespace Profiler
{
    public abstract class Logic : MonoBehaviour
    {
       protected LogicHandler logicHandler;

        // Use this for initialization
        public virtual void LogicStart() { }

        // Update is called once per frame
        public abstract void LogicUpdate();
    }
}