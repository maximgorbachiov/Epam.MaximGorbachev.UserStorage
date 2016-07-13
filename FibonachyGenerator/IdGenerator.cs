using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonachyGenerator
{
    public class IdGenerator : IEnumerator<int>
    {
        private int prevLastValue = 0;
        private int lastValue = 1;
        private int currentValue;

        public int Current
        {
            get
            {
                return currentValue;
            }
        }

        object IEnumerator.Current
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool MoveNext()
        {
            currentValue = prevLastValue + lastValue;
            prevLastValue = lastValue;
            lastValue = currentValue;
            return true;
        }

        public void Reset()
        {
            
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
