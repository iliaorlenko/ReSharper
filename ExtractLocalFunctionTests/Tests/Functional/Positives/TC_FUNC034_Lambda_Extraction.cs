// TC_FUNC034: Extraction of lambda expression body
//
// Scenario:
// The selection is a lambda expression body that is assigned to a Func/Action variable
// The lambda captures a local variable from the outer scope
//
// Action:
// 1. Select the code block between "// --- Start ---" and "// --- End ---"
// 2. Invoke Extract Local Function (Ctrl+R, Ctrl+M => L => Enter)
// 3. In the Extract Local Function dialog select following options
//    - Function Name:
//    - Parameters: all parameters are checked
//    - Return type: <Owner Type>
// 4. Confirm the refactoring
//
// Expected result:
// - The logic of the lambda is extracted into a local function
// - The original lambda now calls the local function
// - Captured variables are passed as parameters to the new local function
//
namespace ExtractLocalFunctionTests.Tests.Functional.Positives
{
    using System;

    internal class TC_FUNC034_Lambda_Extraction_SourceCode
    {
        public int Outer()
        {
            int value = 10;
            Func<int, int> lambda = (x) =>
            {
                // --- Start ---
                return x * value;
                // --- End ---
            };
            return lambda(5);
        }
    }

    internal class TC_FUNC034_Lambda_Extraction_Expected_Result
    {
        public int Outer()
        {
            int value = 10;
            Func<int, int> lambda = (x) =>
            {
                // --- Start ---
                return Value(x, value);
                // --- End ---
            };
            return lambda(5);

            int Value(int x, int i)
            {
                return x * i;
            }
        }
    }
}