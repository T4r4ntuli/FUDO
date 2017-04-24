using UnityEngine;
using System.Collections;

namespace DOD.Logic {
    public class InputManager : MonoBehaviour /*Replace with static class*/ {

        void Start() {

        }
        void Update() {
            if (Input.GetKeyDown(KeyCode.Alpha3)) {
                EntityManager.Instance.DeleteEntity(EntityManager.Instance.entityIDs[0]);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2)) {
                PlayerManager playerManager = PlayerManager.Instance;
                for (int i = 0; i < 500; i++) {
                    playerManager.CreatePlayer();
                }
            }
            if (Input.GetKeyDown(KeyCode.W)) {
                if (true) { //if entity is controllable do something

                }
            }
        }
    }
}