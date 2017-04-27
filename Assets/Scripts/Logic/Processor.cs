namespace Fudo.PRC
{
    public abstract class Processor<T1>
    {
        public virtual void Initialize(GenericDictionary<T1> dict) {

        }
        public virtual void Process(GenericDictionary<T1> dict) {

        }
    }

    public abstract class Processor<T1, T2>
    {
        public virtual void Initialize(GenericDictionary<T1> dict1, GenericDictionary<T2> dict2) {

        }
        public virtual void Process(GenericDictionary<T1> dict1, GenericDictionary<T2> dict2) {

        }
    }

    public abstract class Processor<T1, T2, T3>
    {
        public virtual void Initialize(GenericDictionary<T1> dict, GenericDictionary<T2> dict2, GenericDictionary<T2> dict3) {

        }
    }

    public abstract class Processor<T1, T2, T3, T4>
    {
        public virtual void Initialize(GenericDictionary<T1> dict, GenericDictionary<T2> dict2, GenericDictionary<T2> dict3, GenericDictionary<T2> dict4) {

        }
    }

    public abstract class Processor<T1, T2, T3, T4, T5>
    {
        public virtual void Initialize(GenericDictionary<T1> dict, GenericDictionary<T2> dict2, GenericDictionary<T2> dict3, GenericDictionary<T2> dict4, GenericDictionary<T2> dict5) {

        }
    }

    public abstract class Processor<T1, T2, T3, T4, T5, T6>
    {
        public virtual void Initialize(GenericDictionary<T1> dict) {

        }
    }

    public abstract class Processor<T1, T2, T3, T4, T5, T6, T7>
    {
        public virtual void Initialize(GenericDictionary<T1> dict) {

        }
    }

    public abstract class Processor<T1, T2, T3, T4, T5, T6, T7, T8>
    {
        public virtual void Initialize(GenericDictionary<T1> dict) {

        }
    }

    public abstract class Processor<T1, T2, T3, T4, T5, T6, T7, T8, T9>
    {
        public virtual void Initialize(GenericDictionary<T1> dict) {

        }
    }
}
