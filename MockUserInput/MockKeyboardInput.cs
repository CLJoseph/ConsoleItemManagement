using System;
using System.Collections.Generic;
using System.Text;

namespace MockUserInput
{
    /// <summary>
    /// This class mocks the keyboard input from a user.
    /// can be a single or a sequence of inputs 
    /// 
    /// It is to help in unit testing classes where an input or sequence of inputs 
    /// comes in from a user at a keyboard.
    /// 
    /// Usage
    /// Enter a sequence into a list of elements then as each get or read is called the next
    /// element in the list will be returned. Calling a clear method will empty the list.
    /// 
    /// </summary>
    public class MockKeyboardInput : IUserKeyboardInput
    {
        private int _indexDoubleCount = 0;
        public List<double> ReturnDouble = new List<double>();

        private int _indexIntCount = 0;
        public List<int> ReturnInt = new List<int>();

        private int _indexStringCount = 0;
        public List<string> ReturnString = new List<string>();

        private int _indexCharCount = 0;
        public List<char> ReturnChar = new List<char>();

        public MockKeyboardInput()
        {
            ClearAll();
        }
        public void ClearAll()
        {
            _indexDoubleCount = 0;
            _indexIntCount = 0;
            _indexStringCount = 0;
            _indexCharCount = 0;
            ReturnDouble.Clear();
            ReturnInt.Clear();
            ReturnString.Clear();
            ReturnChar.Clear();
        }
        public void ClearDouble()
        {
            _indexDoubleCount = 0;
            ReturnDouble.Clear();
        }
        public void ClearInt()
        {
            _indexIntCount = 0;
            ReturnInt.Clear();
        }
        public void ClearString()
        {
            _indexStringCount = 0;
            ReturnString.Clear();
        }
        public void ClearChar()
        {
            _indexCharCount = 0;
            ReturnChar.Clear();
        }
        public int getIntValue(string prompt)
        {
            _indexIntCount++;
            return ReturnInt[_indexIntCount-1];
        }
        public double getDoubleValue(string prompt)
        {
            _indexDoubleCount++;
            return ReturnDouble[_indexDoubleCount - 1];
        }
        public string read(string prompt)
        {
            _indexStringCount++;
            return ReturnString[_indexStringCount - 1];
        }
        public char readKey()
        {
            _indexCharCount++;
            return ReturnChar[_indexCharCount - 1];
        }
        public string readLn()
        {

            _indexStringCount++;
            return  ReturnString[_indexStringCount-1];
        }
        public string readLn(string prompt)
        {
            _indexStringCount++;
            return ReturnString[_indexStringCount - 1];
        }

        public char readKey(string prompt)
        {
            _indexCharCount++;
            return ReturnChar[_indexCharCount - 1];
        }
    }
}
