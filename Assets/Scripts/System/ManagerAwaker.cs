using UnityEngine;

namespace Fudo {
    public class ManagerAwaker : Singleton<ManagerAwaker> {
        protected ManagerAwaker() { }

        public override void Init() {
            //Awake all managers

            EntityManager.Instance.Init();
            ComponentManager.Instance.Init();
            ProcessorManager.Instance.Init();
            PlayerManager.Instance.Init();

            EntityManager.Instance.ReferenceManager();
            ComponentManager.Instance.ReferenceManager();
            Debug.Log("INITIALIZE");
            ProcessorManager.Instance.ReferenceManager();
            PlayerManager.Instance.ReferenceManager();
        }
    }
}