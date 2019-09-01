/*
 * Bill Nicholson
 * nicholdw@ucmail.uc.edu
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddingBinaryNumbers {
    class TestMain {
        static void Main(string[] args) {

            Console.WriteLine(BinaryNumber.sizeInBits + " bits of precision...");

            BinaryNumber n1 = new BinaryNumber(new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 });
            BinaryNumber n2 = new BinaryNumber(new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 });
            BinaryNumber answer;
            answer = BinaryNumber.Add(n1, n2);
            answer.Print();
            Console.WriteLine();

            n1 = new BinaryNumber(new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1 });
            n2 = new BinaryNumber(new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1 });
            answer = BinaryNumber.Add(n1, n2);
            answer.Print();
            Console.WriteLine();

            // Should overflow and throw an exception
            n1 = new BinaryNumber(new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1 });
            n2 = new BinaryNumber(new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1 });
            try {
                answer = BinaryNumber.Add(n1, n2);
            }
            catch (BinaryNumberOverflow ex) {
                Console.WriteLine(ex.Message);
            }
            answer.Print();
            Console.WriteLine();
        }
    }
}
