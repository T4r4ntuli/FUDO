namespace Fudo.Processor {
    public static class Input {
        public static void Update() {
            if (UnityEngine.Input.GetKeyDown(UnityEngine.KeyCode.Alpha2)) {
                PlayerManager playerManager = PlayerManager.Instance;
                //for (int i = 0; i < 500; i++) {
                 //   playerManager.CreatePlayer();
                //}
                for (int i = 0; i < 10; i++) {
                    playerManager.CreatePlayer();
                }
            }
            
            if (UnityEngine.Input.GetKeyDown(UnityEngine.KeyCode.Alpha3)) {
                EventManager.TriggerEvent(Enums.Event.Test);
            }

            if (UnityEngine.Input.GetKeyDown(UnityEngine.KeyCode.Alpha4)) {
                PlayerManager playerManager = PlayerManager.Instance;
                for (int i = 0; i < 10; i++) {
                playerManager.CreateMonoPlayer();
                }
            }

            if (UnityEngine.Input.GetKeyDown(UnityEngine.KeyCode.W)) {
                if (true) { //if entity is controllable do something

                }
            }
        }
    }
}