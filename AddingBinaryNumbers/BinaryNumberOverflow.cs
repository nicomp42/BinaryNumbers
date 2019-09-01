using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddingBinaryNumbers {
    class BinaryNumberOverflow : Exception {
        public BinaryNumberOverflow(string message) : base(message) { 
            
        }
    }
}
