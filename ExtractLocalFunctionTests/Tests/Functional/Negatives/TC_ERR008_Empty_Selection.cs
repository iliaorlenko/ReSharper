// TC_ERR009: Edge Cases - Empty Selection

// Scenario:
// Attempt to extract an empty selection (cursor only)

// Action:
// 1. Place the cursor in an empty line or between characters (e.g., inside an empty method body)
// 2. Invoke Extract Local Function (e.g., Ctrl+R, Ctrl+M, L)

// Expected Result:
// A message "The key combination (CTRL+R, CTRL+M) is bound to command (ReSharper_ExtractMethod) which is not currently available." should appear in the status bar

namespace ExtractLocalFunctionTests.Tests.Functional.Negatives
{
    internal class TC_ERR008_Empty_Selection
    {
        public void MyMethod()
        {
            // Cursor here
        }
    }
}
