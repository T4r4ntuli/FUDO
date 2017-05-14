using UnityEngine;

namespace Profiler
{
    public abstract class Logic : MonoBehaviour
    {

        // Use this for initialization
        public virtual void LogicStart() { }

        // Update is called once per frame
        public abstract void LogicUpdate();
    }
}