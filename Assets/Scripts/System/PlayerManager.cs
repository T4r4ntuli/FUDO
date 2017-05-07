using UnityEngine;

namespace Fudo {
    public class PlayerManager : Singleton<PlayerManager> {
        protected PlayerManager() { }

        ComponentManager componentManager;
        EntityManager entityManager;
        public GameObject playerPrefab;

        Transform root;

        public override void Init() {
            root = GameObject.Find("Root").transform;
        }

        public override void ReferenceManager() {
            componentManager = ComponentManager.Instance;
            entityManager = EntityManager.Instance;
        }

        float createSavePointTimer = 0;
        float createSavePointInterval = 20;
        Entity player;

        public void Update() {
            if (createSavePointTimer >= createSavePointInterval) {
                Entity entity = new Entity();
                entity.id = entityManager.GenerateEntityID();
                entityManager.entities.Add(entity.id, entity);

                componentManager.AddComponent(Enums.ComponentType.Position, componentManager.positions[player.id], entity.id);
                componentManager.AddComponent(Enums.ComponentType.Rotation, componentManager.rotations[player.id], entity.id);
            }
        }

        public void CreatePlayer() {
            GameObject go = Instantiate(playerPrefab);
            Entity entity = go.GetComponent<Entity>();
            go.name = "Player";
            go.transform.parent = root;

            entity.id = entityManager.GenerateEntityID();
            entityManager.entities.Add(entity.id, entity);

            componentManager.entityGameObjects.Add(entity.id, go);
            componentManager.entityTransforms.Add(entity.id, go.transform);
            componentManager.rigidbodies.Add(entity.id, go.GetComponent<Rigidbody>());

            componentManager.AddComponent(Enums.ComponentType.Position, Vector3.zero, entity.id);
            componentManager.AddComponent(Enums.ComponentType.Rotation, Quaternion.identity, entity.id);
            componentManager.AddComponent(Enums.ComponentType.Direction, new Vector3(Random.Range(-1, 2), Random.Range(-1, 2), Random.Range(-1, 2)), entity.id);
            componentManager.AddComponent(Enums.ComponentType.MaxSpeed, Random.Range(1, 3), entity.id);
            componentManager.AddComponent(Enums.ComponentType.Movement, new Components.Movement(), entity.id);
            componentManager.AddComponent(Enums.ComponentType.BufferedInputs, new Components.BufferedInputs(), entity.id);
            componentManager.AddComponent(Enums.ComponentType.MovementToInput, new Components.MovementInput(), entity.id);

            int random = Random.Range(0, 4);
            if(random > 1) {
                componentManager.AddComponent(Enums.ComponentType.Controllable, new Components.Controllable(), entity.id);
            }

            //move to acceleration logic
            componentManager.movementComponents[entity.id].velocity = componentManager.rotations[entity.id] *
                componentManager.directions[entity.id].normalized * componentManager.maxSpeeds[entity.id];
        }
    }
}