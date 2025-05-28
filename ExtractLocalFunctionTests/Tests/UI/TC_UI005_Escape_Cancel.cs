// TC_UI005: UI & Keyboard Interaction - Escape to cancel
//
// Scenario:
// Cancel the refactoring using the Escape key
//
// Action:
// 1. Select 'Console.WriteLine("Hello, World!");'
// 2. Invoke Extract Local Function (Ctrl+R, Ctrl+M => L => Enter)
// 3. Press Escape to cancel the refactoring.
//
// Expected Result:
// The pop-up/hint disappears, and no changes are applied to the code

// 4. Repeat steps 1-2
// 5. Press Escape to cancel the refactoring
//
// Expected Result:
// The pop-up/hint disappears, and no changes are applied to the code

namespace ExtractLocalFunctionTests.Tests.UI
{
    internal class TC_UI005_Escape_Cancel_SourceCode
    {
        public void Method()
        {
            Console.WriteLine("Hello, World!");
        }
    }

    internal class TC_UI005_Escape_Cancel_Expected_Result
    {
        public void Method()
        {
            Console.WriteLine("Hello, World!");
        }
    }
}