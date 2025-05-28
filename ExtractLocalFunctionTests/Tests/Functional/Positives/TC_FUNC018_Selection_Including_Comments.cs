// TC_FUNC018: Selection including comments (leading, inline, multi-line)
//
// Scenario:
// The selected code block contains various types of comments
// - Leading single-line comments
// - Inline comments at the end of a line of code
// - Multi-line comments (/* ... */)
//
// Action:
// 1. Select the code block between "// --- Start ---" and "// --- End ---"
// 2. Invoke Extract Local Function (Ctrl+R, Ctrl+M => L => Enter)
// 3. In the Extract Local Function dialog select following options
//    - Parameters: 'value' should be detected
//    - Return type: Should be inferred
// 4. Confirm the refactoring
//
// Expected result:
// - The code block, along with all its contained comments, is extracted into a new local function
// - Comments maintain their positions relative to the code they describe within the new function
//
namespace ExtractLocalFunctionTests.Tests.Functional.Positives
{
    internal class TC_FUNC018_Selection_Including_Comments_SourceCode
    {
        public int Outer(int value)
        {
            int result;
            // --- Start ---
            // This is a leading comment for the operation
            result = value * 2; // This is an inline comment
            /* This is a
               multi-line comment
               explaining the next step */
            result = result + 5;
            // --- End ---
            return result;
        }
    }

    internal class TC_FUNC018_Selection_Including_Comments_Expected_Result
    {
        public int Outer(int value)
        {
            int result;
            // --- Start ---
            result = Result(value);
            // --- End ---
            return result;

            int Result(int i)
            {
                // This is a leading comment for the operation
                result = i * 2; // This is an inline comment
                /* This is a
               multi-line comment
               explaining the next step */
                result = result + 5;
                return result;
            }
        }
    }
}
