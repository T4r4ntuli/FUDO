using UnityEngine;

namespace Profiler
{
    public class UnityMovementLogic : Logic
    {
        private PlayerObject player;
        Rigidbody rigidbody;

        // Use this for initialization
        public void Start() {
            logicHandler = LogicHandler.Instance;
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
        private void OnDestroy() {
            logicHandler.RemoveFromLogicHandler(this);
        }
    }
}
