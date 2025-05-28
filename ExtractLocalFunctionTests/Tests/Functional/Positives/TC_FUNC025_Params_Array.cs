// TC_FUNC025: Extraction involving a 'params' array
//
// Scenario:
// The selected code iterates over or uses a 'params' array passed to the outer method
//
// Action:
// 1. Select the code block between "// --- Start ---" and "// --- End ---"
// 2. Invoke Extract Local Function (Ctrl+R, Ctrl+M => L => Enter)
// 3. In the Extract Local Function dialog select following options
//    - Parameters: 'values' is checked
//    - Return type: local variable
// 4. Confirm the refactoring
//
// Expected result:
// - The extracted local function takes the 'params' array as a normal array parameter
//
namespace ExtractLocalFunctionTests.Tests.Functional.Positives
{
    internal class TC_FUNC025_Params_Array_SourceCode
    {
        public int Outer(params int[] values)
        {
            int result = 0;
            // --- Start ---
            foreach (int val in values)
            {
                result += val;
            }
            // --- End ---
            return result;
        }
    }

    internal class TC_FUNC025_Params_Array_Expected_Result
    {
        public int Outer(params int[] values)
        {
            int result = 0;
            // --- Start ---
            result = Sum(values);
            // --- End ---
            return result;

            int Sum(int[] ints)
            {
                foreach (int val in ints)
                {
                    result += val;
                }

                return result;
            }
        }
    }
}