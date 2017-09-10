using System.Collections;
using System.Collections.Generic;

namespace InterfaceSegregation
{
   
    public class Maybe<T>: IEnumerable<T>
    {
        public readonly IEnumerable<T> values;
        public Maybe()
        {
            this.values = new T[0];
        }

        public Maybe(T value)
        {
            this.values = new[] {value};
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}