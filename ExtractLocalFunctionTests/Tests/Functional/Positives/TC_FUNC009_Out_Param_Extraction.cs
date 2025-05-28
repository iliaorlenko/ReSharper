// TC_FUNC009: Functional - Out Parameter Extraction

// Scenario:
// When an 'out' parameter is explicitly selected as a parameter for the local function, then successfully extracted without errors

// Action:
// 1. Select 'temp = 10; result = temp * 2;'
// 2. Invoke Extract Local Function (Ctrl+R, Ctrl+M => L => Enter)
// 3. In the dialog, ensure 'result' parameter IS CHECKED
// 4. Confirm the refactoring by hitting Enter or clicking Next

// Expected Result:
// Extracted local function takes 'result' as an 'out int' parameter

namespace ExtractLocalFunctionTests.Tests.Functional.Positives
{
    internal class TC_FUNC009_Out_Param_Extraction_Explicit_Parameters_SourceCode
    {
        public void Outer(out int result)
        {
            result = 1;
        }
    }

    internal class TC_FUNC009_Out_Param_Extraction_Explicit_Parameters_Expected_Result
    {
        public void Outer(out int result)
        {
            NewFunction(out result);

            void NewFunction(out int i)
            {
                i = 1;
            }
        }
    }
}