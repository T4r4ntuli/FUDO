using UnityEngine;

namespace Fudo {
    public class PlayerManager : Singleton<PlayerManager> {
        protected PlayerManager() { }


        ComponentManager componentManager;
        EntityManager entityManager;
        public GameObject playerPrefab;

        public override void Init() {
            
        }
        public override void ReferenceManager() {
            componentManager = ComponentManager.Instance;
            entityManager = EntityManager.Instance;
        }

        public void CreatePlayer() {
            //GameObject go = new GameObject();
            //Entity entity = go.AddComponent(typeof(Entity)) as Entity;
            GameObject go = Instantiate(playerPrefab);
            Entity entity = go.GetComponent<Entity>();
            go.name = "Player";

            entity.id = entityManager.GenerateEntityID();

            componentManager.entityGameObjects.Add(entity.id, go);
            componentManager.entityTransforms.Add(entity.id, go.transform);
            componentManager.rigidbodies.Add(entity.id, go.GetComponent<Rigidbody>());
            componentManager.positions.Add(entity.id, Vector3.zero);
            componentManager.movementComponents.Add(entity.id, new Components.Movement());
            componentManager.movementComponents[entity.id].velocity = new Vector3(Random.Range(-2, 2), Random.Range(-2, 2), Random.Range(-2, 2));
        }
    }
}