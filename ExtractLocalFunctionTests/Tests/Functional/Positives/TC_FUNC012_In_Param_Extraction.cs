// TC_FUNC012: Functional - In Parameter Extraction

// Scenario:
// The extracted local function should declare an 'in' parameter, preserving the input-only semantics

// Action:
// 1. Select 'Console.WriteLine(value);'
// 2. Invoke Extract Local Function (Ctrl+R, Ctrl+M => L => Enter)
// 3. Confirm the refactoring by hitting Enter or clicking Next.
// !!!BUG!!! (It doesn't add 'in' modifier, dialog also doesn't contain 'in' modifier in the grid. Probably C# 7.2+ version is not supported?)

// Expected Result:
// The extracted function takes argument as an 'in int' parameter, and the call site passes 'value' with 'in' modifier

namespace ExtractLocalFunctionTests.Tests.Functional.Positives
{
    internal class TC_FUNC012_In_Param_Extraction_SourceCode
    {
        public void Outer(in int value)
        {
            Console.WriteLine(value);
        }
    }

    internal class TC_FUNC012_In_Param_Extraction_Expected_Result
    {
        public void Outer(in int value)
        {
            NewFunction(in value);

            void NewFunction(in int i)
            {
                Console.WriteLine(i);
            }
        }
    }
}