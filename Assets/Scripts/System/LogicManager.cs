using System.Collections;
using Fudo.PRC;

namespace Fudo {
    public class LogicManager : Singleton<LogicManager> {
        protected LogicManager() { }
        // TARKISTA MITEN LOGIIKKAMANAGERI INITIALISOIDAAN

        private ComponentManager componentManager;
        
        //public GetReferencesToOtherManagers() { }
        // CHECK EXAMPLE FROM OTHER MANAGERS
        // MANAGER AWAKER HOX

        public override void Init() {
            componentManager = ComponentManager.Instance;
        }

        void Start() {

        }
        void Update() {
            // TÄMÄ ON SE MALLI
            StaticMovementProcessor.Process(componentManager.positions, componentManager.movementComponents);
        }
        void FixedUpdate() {

        }
    }
}