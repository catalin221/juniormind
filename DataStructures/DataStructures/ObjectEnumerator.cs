using System.Collections;

namespace DataStructures
{
    public class ObjectEnumerator : IEnumerator
    {
        private readonly ObjArrayCollection objArray;
        private int index = -1;

        public ObjectEnumerator(ObjArrayCollection obj)
        {
            objArray = obj;
        }

        object IEnumerator.Current { get; }

        public object Current()
        {
            return objArray[index];
        }

        public bool MoveNext()
        {
            index++;
            return index < objArray.Count;
        }

        public void Reset()
        {
            index = -1;
        }
    }
}
