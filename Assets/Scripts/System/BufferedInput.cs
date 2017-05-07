using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fudo
{
    [System.Serializable]
    public class BufferedInput
    {
        public BufferedInput(Enums.Key key, Enums.KeyState state) {
            this.key = key;
            this.state = state;
        }

        public Enums.Key key { get;  protected set; }
        public Enums.KeyState state { get; protected set; }
    }

}
