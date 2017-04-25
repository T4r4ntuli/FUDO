using UnityEngine;

namespace Fudo {
    public class ManagerAwaker : MonoBehaviour {
        
        public void Awake() {
            //Awake all managers

            EntityManager.Instance.Init();
            ComponentManager.Instance.Init();
            LogicManager.Instance.Init();
            PlayerManager.Instance.Init();

            EntityManager.Instance.ReferenceManager();
            ComponentManager.Instance.ReferenceManager();
            LogicManager.Instance.ReferenceManager();
            PlayerManager.Instance.ReferenceManager();
        }
    }
}