// TC_ERR007: Edge Cases - Empty Selection

// Scenario:
// Attempt to extract comment only line

// Action:
// 1. Select a line containing comment only
// 2. Invoke Extract Local Function (e.g., Ctrl+R, Ctrl+M, L) !!!BUG!!!

// A message "The key combination (CTRL+R, CTRL+M) is bound to command (ReSharper_ExtractMethod) which is not currently available." should appear in the status bar

namespace ExtractLocalFunctionTests.Tests.Functional.Negatives
{
    internal class TC_ERR007_Comment_Only
    {
        public void Method()
        {
            // Select and extract me
        }
    }
}