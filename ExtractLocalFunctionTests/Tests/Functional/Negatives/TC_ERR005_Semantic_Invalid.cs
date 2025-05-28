// TC_ERR005: Invalid Code Selection - Semantically Invalid Extraction

// Scenario:
// Attempt to extract a local function from code that is syntactically valid but semantically cannot be extracted (e.g., variable declared inside selection, used outside, but not initialized).

// Action:
// 1. Select 'int x;'.
// 2. Invoke Extract Local Function (e.g., Ctrl+R, Ctrl+M)  !!!BUG!!!

// Expected Result: The refactoring should not be available, or a specific error message indicating why the extraction is not possible

namespace ExtractLocalFunctionTests.Tests.Functional.Negatives
{
    using System;
 
    internal class TC_ERR005_Semantic_Invalid
    {
        public void MyMethod()
        {
            int x;
            x = 10;
            Console.WriteLine(x);
        }
    }
}
