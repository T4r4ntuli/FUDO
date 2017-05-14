using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Profiler
{
    public class UnityMovementLogic : Logic
    {
        private PlayerObject player;
        Rigidbody rigidbody;

        // Use this for initialization
        public void Start() {
            LogicHandler logicHandler = GameObject.Find("Root").GetComponent<LogicHandler>();
            rigidbody = GetComponent<Rigidbody>();
            player = GetComponent<PlayerObject>();
            logicHandler.AddToLogicHandler(this);
        }

        // Update is called once per frame
        public override void LogicUpdate() {
            if (rigidbody != null) {
                rigidbody.MovePosition(player.position);
            } else {
                transform.position = player.position;
            }
        }
    }
}
