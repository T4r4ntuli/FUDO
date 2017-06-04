using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Profiler
{
    public class LogicHandler : Fudo.Singleton<LogicHandler>
    {
        protected LogicHandler() { }

        public List<Logic> logics;

        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {
            foreach (Logic logic in logics) {
                logic.LogicUpdate();
            }
        }

        public void AddToLogicHandler(Logic logic) {
            logics.Add(logic);
        }

        public void RemoveFromLogicHandler(Logic logic) {
            logics.Remove(logic);
        }
    }
}
