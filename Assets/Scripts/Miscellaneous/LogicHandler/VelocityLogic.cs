using UnityEngine;

namespace Profiler
{
    public class VelocityLogic : Logic
    {
        private PlayerObject player;

        public void Start() {
            logicHandler = LogicHandler.Instance;
            player = GetComponent<PlayerObject>();
            player.direction = new Vector3(Random.Range(-1, 2), Random.Range(-1, 2), Random.Range(-1, 2));
            //while (player.direction.magnitude == 0) {
            //    player.direction = new Vector3(Random.Range(-1, 2), Random.Range(-1, 2), Random.Range(-1, 2));
            //}
            logicHandler.AddToLogicHandler(this);
        }

        public override void LogicUpdate() {
            player.direction = player.direction.normalized;
            player.velocity = player.rotation * player.direction * player.movementSpeed;
        }

        private void OnDestroy() {
            logicHandler.RemoveFromLogicHandler(this);
        }
    }
}
