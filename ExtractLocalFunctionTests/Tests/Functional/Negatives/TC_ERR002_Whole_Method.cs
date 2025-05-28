// TC_ERR002: Invalid Code Selection - Entire Method

// Scenario: Attempt to extract a local function from an entire method signature, including its body

// Action:
// 1. Select the entire 'public void Method() { ... }' definition
// 2. Invoke Extract Local Function (e.g., Ctrl+R, Ctrl+M, L)

// Expected Result:
// A message "The key combination (CTRL+R, CTRL+M) is bound to command (ReSharper_ExtractMethod) which is not currently available." should appear in the status bar

namespace ExtractLocalFunctionTests.Tests.Functional.Negatives
{
    using System;

    internal class TC_ERR002_Whole_Method
    {
        public void Method()
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
