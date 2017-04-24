using UnityEngine;

namespace DOD {
    public class Entity : MonoBehaviour {

        public int id;

        //Basicly draws components in it, gives choices to add or delete component from it
        void Update() { //Replace with property drawer
            Vector3 position;
            if (ComponentManager.Instance.positions.TryGetValue(id, out position)) {
                //Debug.Log(position);
                //Draw position
            }
        }
    }


}
