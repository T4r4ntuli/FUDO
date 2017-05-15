using UnityEngine;

namespace Fudo.Processor {
    public static class Input {
        public static void Update() {
            if (UnityEngine.Input.GetKeyDown(UnityEngine.KeyCode.Alpha2)) {
                PlayerManager playerManager = PlayerManager.Instance;
                //for (int i = 0; i < 500; i++) {
                 //   playerManager.CreatePlayer();
                //}
                for (int i = 0; i < 1000; i++) {
                    playerManager.CreatePlayer();
                }
            }
            
            if (UnityEngine.Input.GetKeyDown(UnityEngine.KeyCode.Alpha3)) {
                EventManager.Instance.TriggerEvent(Enums.Event.Test);
            }

            if (UnityEngine.Input.GetKeyDown(UnityEngine.KeyCode.Alpha4)) {
                PlayerManager playerManager = PlayerManager.Instance;
                for (int i = 0; i < 1000; i++) {
                playerManager.CreateMonoPlayer();
                }
            }

            if (UnityEngine.Input.GetKeyDown(UnityEngine.KeyCode.Alpha5)) {
                PlayerManager playerManager = PlayerManager.Instance;
                for (int i = 0; i < 1000; i++) {
                    playerManager.CreateLogicPlayer();
                }
            }

            if (UnityEngine.Input.GetKeyDown(UnityEngine.KeyCode.Alpha0)) {
                //GameObject[] gos = GameObject.FindGameObjectsWithTag("Player");
                //foreach (GameObject go in gos) {
                //    GameObject.Destroy(go);
                //}

                EntityManager entityManager = EntityManager.Instance;
                foreach (Entity entity in entityManager.entities.Values) {
                    entityManager.DeleteEntity(entity.id);
                }
                entityManager.entities.Clear();
            }

            if (UnityEngine.Input.GetKeyDown(UnityEngine.KeyCode.W)) {
                EventManager.Instance.TriggerEvent(Enums.Event.Test, new int[] { 1, 0, 1 });
                if (true) { //if entity is controllable do something

                }
            }
        }
    }
}