// TC_FUNC011: Functional - Ref parameter extraction when variable is assigned and accessed

// Scenario:
// Extracting code that first reads the value of a 'ref' parameter from the outer method and then modifies it. This requires the local function's parameter to also be 'ref'

// Action:
// 1. Select 'result += 1;'
// 2. Invoke Extract Local Function (Ctrl+R, Ctrl+M => L => Enter)
// 3. In the dialog, ensure 'result' parameter IS CHECKED
// 4. Confirm the refactoring by hitting Enter or clicking Next

// Expected Result:
// The extracted function takes argument as a 'ref int' parameter, and the call site passes 'result' with 'ref' modifier

namespace ExtractLocalFunctionTests.Tests.Functional.Positives
{
    internal class TC_FUNC011_Ref_Param_Extraction_Read_Then_Modified_SourceCode
    {
        public void Method(ref int result)
        {
            result += 1;
        }
    }

    internal class TC_FUNC011_Ref_Param_Extraction_Read_Then_Modified_Expected_Result
    {
        public void Method(ref int result)
        {
            NewFunction(ref result);

            void NewFunction(ref int i)
            {
                i += 1;
            }
        }
    }
}