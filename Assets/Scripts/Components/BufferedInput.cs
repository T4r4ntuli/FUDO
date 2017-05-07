using System.Collections.Generic;

namespace Fudo.Components {
    [System.Serializable]
    public class BufferedInputs {
        public BufferedInputs() {
            inputs = new List<BufferedInput>();
        }
        public List<BufferedInput> inputs;
    }
}
