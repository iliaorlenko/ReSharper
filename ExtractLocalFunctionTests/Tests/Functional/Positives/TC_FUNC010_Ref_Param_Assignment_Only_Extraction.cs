// TC_FUNC010: Functional - Ref parameter extraction when variable is assigned and accessed

// Scenario:
// The extracted local function should declare a 'ref' parameter, and the call site should pass the outer 'ref' parameter

// Action:
// 1. Select 'result = 1;'
// 2. Invoke Extract Local Function (Ctrl+R, Ctrl+M => L => Enter)
// 3. In the 'Extract Local Function' dialog window, ensure 'result' parameter IS CHECKED
// 3. Confirm the refactoring by hitting Enter or clicking Next

// Expected Result:
// The extracted function takes argument as an 'out int' parameter, and the call site passes 'result' with 'out' modifier

namespace ExtractLocalFunctionTests.Tests.Functional.Positives
{
    internal class TC_FUNC010_Ref_Param_Assignment_Only_Extraction_SourceCode
    {
        public void Outer(ref int result)
        {
            result = 1;
        }
    }

    internal class TC_FUNC010_Ref_Param_Assignment_Only_Extraction_Expected_Result
    {
        public void Outer(ref int result)
        {
            NewFunction(out result);

            void NewFunction(out int i)
            {
                i = 1;
            }
        }
    }
}
