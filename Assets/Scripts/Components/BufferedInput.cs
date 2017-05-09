using System.Collections.Generic;

namespace Fudo.Components {
    [System.Serializable]
    public class BufferedInputs {
        public BufferedInputs() {
            buffered = new List<BufferedInput>();
        }
        public List<BufferedInput> buffered;
    }
}
