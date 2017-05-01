using UnityEngine;

namespace Fudo.Proc {
    public static class InputProcessor {

        public static void Update() {
            if (Input.GetKeyDown(KeyCode.Alpha2)) {
                PlayerManager playerManager = PlayerManager.Instance;
                //for (int i = 0; i < 500; i++) {
                    playerManager.CreatePlayer();
                //}
            }
            if (Input.GetKeyDown(KeyCode.Alpha3)) {
                EventManager.TriggerEvent(Enums.Event.Test);
            }
            if (Input.GetKeyDown(KeyCode.W)) {
                if (true) { //if entity is controllable do something

                }
            }
        }
    }
}