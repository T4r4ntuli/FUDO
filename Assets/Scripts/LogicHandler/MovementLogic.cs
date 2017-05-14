using UnityEngine;

namespace Profiler
{
    public class MovementLogic : Logic
    {
        private PlayerObject player;

        public void Start() {
            LogicHandler logicHandler = GameObject.Find("Root").GetComponent<LogicHandler>();
            player = GetComponent<PlayerObject>();
            logicHandler.AddToLogicHandler(this);
        }

        public override void LogicUpdate() {
            player.position = player.position + player.velocity * Time.deltaTime;
        }
    }
}
