// TC_FUNC028: Code selection containing preprocessor directives
//
// Scenario:
// The selected code block contains #if/#else/#endif preprocessor directives
//
// Action:
// 1. Select the code block between "// --- Start ---" and "// --- End ---"
// 2. Invoke Extract Local Function (Ctrl+R, Ctrl+M => L => Enter)
// 3. In the Extract Local Function dialog select following options
//    - Return type: local variable
//    - Params: no params are suggested to be selected
// 4. Confirm the refactoring
//
// Expected result:
// - The preprocessor directives are moved into the extracted local function
// - The extracted function correctly reflects the conditional logic
//
// !!!BUG!!! Minor  extracted function call has no indentation (it is on the same level as directives)
#define DEBUG_FEATURE
namespace ExtractLocalFunctionTests.Tests.Functional.Positives
{
    internal class TC_FUNC028_Preprocessor_Directives_SourceCode
    {
        public int Outer()
        {
            int value = 0;
            // --- Start ---
#if DEBUG_FEATURE
            value = 1;
#else
            value = 2;
#endif
            value = 3;
            // --- End ---
            return value;
        }
    }

    internal class TC_FUNC028_Preprocessor_Directives_Expected_Result
    {
        public int Outer()
        {
            int value;
            // --- Start ---
            value = Value();
            // --- End ---
            return value;

            int Value()
            {
#if DEBUG_FEATURE
                value = 1;
#else
                value = 2;
#endif
                value = 3;
                return value;
            }
        }
    }
}