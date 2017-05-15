namespace Fudo {
    public class ManagerAwaker : Singleton<ManagerAwaker> {
        protected ManagerAwaker() { }

        private void Awake() {
            Init();
        }

        public override void Init() {
            //Awake all managers

            EntityManager.Instance.Init();
            EventManager.Instance.Init();
            ComponentManager.Instance.Init();
            ProcessorManager.Instance.Init();
            PlayerManager.Instance.Init();

            EntityManager.Instance.ReferenceManager();
            ComponentManager.Instance.ReferenceManager();
            ProcessorManager.Instance.ReferenceManager();
            PlayerManager.Instance.ReferenceManager();
        }
    }
}