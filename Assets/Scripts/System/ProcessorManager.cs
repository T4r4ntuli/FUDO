namespace Fudo {
    public class ProcessorManager : Singleton<ProcessorManager> {
        protected ProcessorManager() { }

        private ComponentManager componentManager;

        public override void ReferenceManager() {
            componentManager = ComponentManager.Instance;
        }

        private void Start() {


            /*
                EVENT MANAGER

                COLLISION MANAGER

                CAPSULE CAST / MULTIPLE RAYCAST TO CHECK COLLISIONS
                IF COLLISION INVERT DIRECTION

                HOW TO SEND EVENT TO ONE PARTICULAR OBJECT
                HOT TO SEND EVENT TO A GROUP OF OBJECTS
            

             
             */


        }

        private void Update() {
            Processor.RawInput.Update(componentManager.playerInput);
            Processor.RawInputToAxis.Update(componentManager.controllableComponents, componentManager.playerInput);
            Processor.Input.Update();
            Processor.AxisToDirection.Update(componentManager.controllableComponents, componentManager.directions);
            Processor.Velocity.Update(componentManager.movementComponents, componentManager.directions, componentManager.rotations, componentManager.maxSpeeds);
            Processor.Movement.Update(componentManager.positions, componentManager.movementComponents);
            Processor.UnityMovement.Update(componentManager.entityTransforms, componentManager.positions, componentManager.rigidbodies);
        }
        private void FixedUpdate() {
            
        }

        private void LateUpdate() {

        }
    }
}