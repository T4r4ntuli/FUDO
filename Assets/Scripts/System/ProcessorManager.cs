namespace Fudo {
    public class ProcessorManager : Singleton<ProcessorManager> {
        protected ProcessorManager() { }

        private ComponentManager componentManager;

        public override void ReferenceManager() {
            componentManager = ComponentManager.Instance;
        }

        private void Start() {

        }

        private void Update() {
            Processor.Input.Update();
            Processor.Movement.Update(componentManager.positions, componentManager.movementComponents);
            Processor.UnityMovement.Update(componentManager.entityTransforms, componentManager.positions, componentManager.rigidbodies);
        }
        private void FixedUpdate() {

        }

        private void LateUpdate() {

        }
    }
}