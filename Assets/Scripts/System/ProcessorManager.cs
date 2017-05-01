using UnityEngine;
using Fudo.Proc;

namespace Fudo {
    public class ProcessorManager : Singleton<ProcessorManager> {
        protected ProcessorManager() { }

        private ComponentManager componentManager;


        public override void ReferenceManager() {
            Debug.Log("FETCH");
            componentManager = ComponentManager.Instance;
        }

        private void Start() {

        }

        private void Update() {
            Debug.Log("UPDATE");
            InputProcessor.Update();
            MovementProcessor.Update(componentManager.positions, componentManager.movementComponents);
            UnityMovementProcessor.Update(componentManager.entityTransforms, componentManager.positions, componentManager.rigidbodies);
        }
        private void FixedUpdate() {

        }

        private void LateUpdate() {

        }
    }
}