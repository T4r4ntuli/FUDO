using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Fudo {
    public class EntityManager : Singleton<EntityManager> {
        protected EntityManager() { }

        ComponentManager componentManager;

        public List<int> entityIDs;

        public List<Dictionary<int, int>> intDictionaries;        
        public List<Dictionary<int, float>> floatDictionaries;     
        public List<Dictionary<int, bool>> boolDictionaries;
        public List<Dictionary<int, Vector3>> vectorDictionaries;
        public List<Dictionary<int, Quaternion>> quaternionDictionaries;
        public List<Dictionary<int, Components.Movement>> movementDictionaries;

        public override void Init() {
            entityIDs = new List<int>();

            intDictionaries = new List<Dictionary<int, int>>();
            floatDictionaries = new List<Dictionary<int, float>>();
            boolDictionaries = new List<Dictionary<int, bool>>();
            vectorDictionaries = new List<Dictionary<int, Vector3>>();
            quaternionDictionaries = new List<Dictionary<int, Quaternion>>();
            movementDictionaries = new List<Dictionary<int, Components.Movement>>();
        }
        public override void ReferenceManager() {
            componentManager = ComponentManager.Instance;
        }

        public int GenerateEntityID() {
            int id = Random.Range(0, 10000);

            if (entityIDs.Contains(id)) {
                return GenerateEntityID();
            } else {
                entityIDs.Add(id);
                return id;
            }
        }

        public void DeleteEntity(int id) {
            if(entityIDs.Remove(id)) {
                foreach (Dictionary<int, int> dictionary in intDictionaries) {
                    dictionary.Remove(id);
                }
                foreach (Dictionary<int, float> dictionary in floatDictionaries) {
                    dictionary.Remove(id);
                }
                foreach (Dictionary<int, Vector3> dictionary in vectorDictionaries) {
                    dictionary.Remove(id);
                }
                foreach (Dictionary<int, Components.Movement> dictionary in movementDictionaries) {
                    dictionary.Remove(id);
                }

                //Remove all references of Unity components and objects
                componentManager.rigidbodies.Remove(id);
                componentManager.entityTransforms.Remove(id);
                GameObject go;
                if (componentManager.entityGameObjects.TryGetValue(id, out go)) {
                    Destroy(go);
                    Debug.Log("Deleted gameObject succesfully");
                }
                Debug.Log("Deleted entity succesfully");
            } else {
                Debug.Log("Did not found entity with this id");
            }
        }
    }
}