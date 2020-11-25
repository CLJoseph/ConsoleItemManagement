using System;
using System.Collections.Generic;
using System.Text;

namespace MockUserInput
{
    public interface IUserKeyboardInput
    {
        string readLn();
        string readLn(string prompt);
        string read(string prompt);
        char readKey();
        double getDoubleValue(string prompt);
        int getIntValue(string prompt);
    }
}
