// TC_ERR004: Invalid Code Selection - Syntax Errors

// Scenario:
// Attempt to extract a local function from code that contains syntax errors

// Action:
// 1. Select 'int x = ; Console.WriteLine(x);'.
// 2. Invoke Extract Local Function (e.g., Ctrl+R, Ctrl+M, L) !!!BUG!!!

// Expected Result:
// The refactoring should not be available, or an error message indicating invalid syntax should be displayed

namespace ExtractLocalFunctionTests.Tests.Functional.Negatives
{
    using System;

    internal class TC_ERR004_Syntax_Errors
    {
        public void MyMethod()
        {
            //int x = ;
            //Console.WriteLine(x);
        }
    }
}
