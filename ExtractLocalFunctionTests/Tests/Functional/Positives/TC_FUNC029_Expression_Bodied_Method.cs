// TC_FUNC029: Extraction from an expression-bodied method
//
// Scenario:
// The outer method is an expression-bodied method
// The selection is part of the expression
//
// Action:
// 1. Select the code block between "// --- Start ---" and "// --- End ---" (the expression part)
// 2. Invoke Extract Local Function (Ctrl+R, Ctrl+M => L => Enter)
// 3. In the Extract Local Function dialog select following options
//    - Parameters: 'a', 'b'
//    - Return type: int
// 4. Confirm the refactoring
//
// Expected result:
// - The selected expression is extracted into a local function
// - The outer method is converted to a block-bodied method to call the local function
// - !!!BUG!!! The same naming problem - first param is called "i", further ones - "1" added to the original
namespace ExtractLocalFunctionTests.Tests.Functional.Positives
{
    internal class TC_FUNC029_Expression_Bodied_Method_SourceCode
    {
        public int Outer(int value, int result) =>
            // --- Start ---
            (value + result) * 2;
            // --- End ---
    }

    internal class TC_FUNC029_Expression_Bodied_Method_Expected_Result
    {
        public int Outer(int a, int b)
        {
            // --- Start ---
            return Result(a, b);

            static int Result(int value1, int result1)
            {
                return (value1 + result1);
            }
        }
        // --- End ---
    }
}