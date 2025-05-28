// TC_UI004: UI & Keyboard Interaction - Enter to confirm
//
// Scenario:
// Successfully extract a simple statement using Enter key
//
// Action:
// 1. Select 'Console.WriteLine("Hello, World!");'
// 2. Invoke Extract Local Function (Ctrl+R, Ctrl+M => L => Enter)
// 3. Press down keyboard arrow button to select "Extract Local Function" option
// 4. Press Enter to confirm => Extract Method dialog is displayed
// 5. Press Enter again to confirm default extraction settings
//
// Expected Result:
// The selected code is refactored into a local function, and Extract Method dialog disappears

namespace ExtractLocalFunctionTests.Tests.UI
{
    internal class TC_UI004_Enter_Confirm_SourceCode
    {
        public void Method()
        {
            Console.WriteLine("Hello, World!");
        }
    }

    internal class TC_UI004_Enter_Confirm_Expected_Result
    {
        public void Method()
        {
            LocalFunction();

            void LocalFunction()
            {
                Console.WriteLine("Hello, World!");
            }
        }
    }
}