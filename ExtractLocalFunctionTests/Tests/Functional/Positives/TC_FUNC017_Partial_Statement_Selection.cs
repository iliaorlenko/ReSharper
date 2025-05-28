// TC_FUNC017: Partial statement selection (expansion to full statement)
//
// Scenario:
// The user selects only a part of a C# statement, for example, an expression
// that is part of an assignment or a method call's argument
//
// Action:
// 1. Select "value + 5;" part of the assignment expression
// 2. Invoke Extract Local Function (Ctrl+R, Ctrl+M => L => Enter)
// 3. In the Extract Local Function dialog select following options
//    - Parameters: 'value' should be selected
//    - Return type: Should be inferred as 'int'
// 4. Confirm the refactoring
//
// Expected result:
// - The partially selected code block is expanded and extracted correctly into a new local function
// - The new function uses 'value' as a parameter and the original line is updated to call it
//
namespace ExtractLocalFunctionTests.Tests.Functional.Positives
{
    internal class TC_FUNC017_Partial_Statement_Selection_SourceCode
    {
        public void Outer(int value)
        {
            int result;
            result = value + 5;
        }
    }

    internal class TC_FUNC017_Partial_Statement_Selection_Expected_Result
    {
        public void Outer(int value)
        {
            int result;
            // --- Start ---
            result = Result(value);
            // --- End ---
            int Result(int i)
            {
                return i + 5;
            }
        }
    }
}