using ConsoleItemManagement.Classes;
using MockUserInput;
using System;
using Xunit;

namespace UnitTestItemManagement
{
    public class UnitTests
    {
        /// <summary>
        /// Test that from the main menu the keypresses A A generate the addtoStock UserAction
        /// </summary>
        [Fact]
        public void KeyPressEventAction_OnKeyPress_KeySequenceAA()
        {
            MockKeyboardInput mockKeyboardInput = new MockKeyboardInput();
            KeyPressEventAction KeyPress = new KeyPressEventAction(mockKeyboardInput);
            mockKeyboardInput.ClearChar();
            // check starting from the main menu
            Assert.Equal(Banner.mainMenu.ToString(), KeyPress.banner.ToString());
          
            mockKeyboardInput.ReturnChar.Add('A');
            mockKeyboardInput.ReturnChar.Add('A');
            var result =  KeyPress.onKeyPress();
            var expected = UserAction.showBannerAdd;          
            Assert.Equal(expected, result);
            // pass test
            KeyPress.banner = Banner.addMenu;
            expected = UserAction.addToStock;
            result = KeyPress.onKeyPress();
            Assert.Equal(expected,result);
        }





    }
}
