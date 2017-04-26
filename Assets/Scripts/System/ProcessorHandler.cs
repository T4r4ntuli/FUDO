using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fudo
{
    public class ProcessorHandler : MonoBehaviour
    {
        Fudo.PRC.MovementProcessor movement;
        ComponentManager componentManager;
        GenericDictionary<Vector3> positions;
        GenericDictionary<Components.Movement> movementComponents;

        // Use this for initialization
        void Start() {
            componentManager = ComponentManager.Instance;
            //positions = componentManager.positions;
            //movementComponents = componentManager.movementComponents;
        }

        // Update is called once per frame
        void Update() {
            movement.Process(positions, movementComponents);
        }

        void LateUpdate() {

        }
    }

}
