// TC_ERR010: Error Handling - Out parameter cannot be captured by a closure

// Scenario:
// Attempting to extract code that assigns a value to an 'out' parameter of the enclosing method, but without explicitly passing to the extracted function

// Action:
// 1. Select 'result = 1;'
// 2. Invoke Extract Local Function (Ctrl+R, Ctrl+M => L => Enter)
// 3. In the extraction dialog, ensure 'result' parameter is NOT checked
// 4. Confirm the refactoring by hitting Enter or clicking Next !!!BUG!!!

// Expected Behavior:
// Extraction without selecting out parameter should be prevented

namespace ExtractLocalFunctionTests.Tests.Functional.Negatives
{
    internal class TC_ERR010_Out_Param_Extraction
    {
        public void Method(out int result)
        {
            result = 1;
        }
    }
}