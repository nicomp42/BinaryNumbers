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
    /// <summary>
    /// Manipulating binary numbers represented as integer arrays of bits
    /// </summary>
    class BinaryNumber {
        public const int sizeInBits = 32;
        private int[] mBits = new int[sizeInBits];
        static void Main(string[] args) {
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
            } catch (BinaryNumberOverflow ex) {
                Console.WriteLine(ex.Message);
            }
            answer.Print();
            Console.WriteLine();
        }
        public BinaryNumber() {
            bits = (new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 });
        }
        public BinaryNumber(int [] theBits) {
            for (int i=0; i < sizeInBits; i++) { bits[i] = theBits[i]; }
        }
        public int[] bits {
            get { return mBits; }
            set { mBits = value; }  // This is BAD.
        }
        public static BinaryNumber Add(BinaryNumber num1, BinaryNumber num2) {
            BinaryNumber result = new BinaryNumber();
            int carry = 0;
            int bitTotal;
            for (int i = sizeInBits - 1; i >= 0; i--) {
                bitTotal = carry + num1.bits[i] + num2.bits[i];
                switch (bitTotal) {
                case 0:
                    result.bits[i] = 0;
                    carry = 0;
                break;
                case 1:
                    result.bits[i] = 1;
                    carry = 0;
                break;

                case 2:
                    result.bits[i] = 0;
                    carry = 1;             
                break;
                case 3:
                    result.bits[i] = 1;
                    carry = 1;
                break;
                }
            }
            if (carry == 1) {
                throw new BinaryNumberOverflow("Addition overflow");
            }
            return result;
        }
        public void Print() {
            for (int i = 0; i < sizeInBits; i++) {
                Console.Write(this.bits[i]);
            }
        }

    }
}
