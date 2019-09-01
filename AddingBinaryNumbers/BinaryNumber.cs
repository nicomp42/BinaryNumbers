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
        public BinaryNumber() {
            bits = new int[sizeInBits];
            for (int i = 0; i < sizeInBits; i++) {bits[i] = 0;}
        }
        public BinaryNumber(int [] theBits) {
            for (int i=0; i < sizeInBits; i++) { mBits[i] = theBits[i]; }
        }
        public int[] bits {
            //get { return mBits; }     // This is BAD
            get { return (int[]) mBits.Clone(); }
            //set { mBits = value; }    // This is BAD.
            set { value.CopyTo(mBits, 0); /* for (int i = 0; i < sizeInBits; i++) { mBits[i] = value[i]; } */ }
        }
        public static BinaryNumber Add(BinaryNumber num1, BinaryNumber num2) {
            BinaryNumber result = new BinaryNumber();
            int carry = 0;
            int bitTotal;
            for (int i = sizeInBits - 1; i >= 0; i--) {
                bitTotal = carry + num1.bits[i] + num2.bits[i];
                switch (bitTotal) {
                case 0:
                    result.mBits[i] = 0;
                    carry = 0;
                break;
                case 1:
                    result.mBits[i] = 1;
                    carry = 0;
                break;

                case 2:
                    result.mBits[i] = 0;
                    carry = 1;             
                break;
                case 3:
                    result.mBits[i] = 1;
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
            for (int i = 0; i < BinaryNumber.sizeInBits; i++) {
                Console.Write(this.bits[i]);
            }
        }

    }
}
