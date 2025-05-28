// TC_ERR003: Invalid Code Selection - Entire Class

// Scenario:
// Attempt to extract a local function from an entire class definition

// Action:
// 1. Select the entire 'internal class TC_ERR003_Whole_Class { ... }' definition
// 2. Invoke Extract Local Function (e.g., Ctrl+R, Ctrl+M)

// Expected Result:
// The refactoring should not be available
// A message "The key combination (CTRL+R, CTRL+M) is bound to command (ReSharper_ExtractMethod) which is not currently available." should appear in the status bar

namespace ExtractLocalFunctionTests.Tests.Functional.Negatives
{
    using System;

    internal class TC_ERR003_Whole_Class
    {
        public void MyMethod()
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
