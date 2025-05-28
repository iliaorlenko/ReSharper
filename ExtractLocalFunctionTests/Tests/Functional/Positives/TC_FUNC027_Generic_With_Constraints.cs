// TC_FUNC027: Generic method with constraints, extracted local function uses generic type
//
// Scenario:
// The outer method is generic with a 'where T : class' constraint
// The selected code uses the generic type 'T'
//
// Action:
// 1. Select the code block between "// --- Start ---" and "// --- End ---"
// 2. Invoke Extract Local Function (Ctrl+R, Ctrl+M => L => Enter)
// 3. In the Extract Local Function dialog select following options
//    - Parameters: both params are checked
//    - Return type: local variable
// 4. Confirm the refactoring
//
// Expected result:
// - The extracted local function is generic with the same type parameter 'T' and respects the constraint
//
namespace ExtractLocalFunctionTests.Tests.Functional.Positives
{
    internal class TC_FUNC027_Generic_With_Constraints_SourceCode
    {
        public T? Outer<T>(T? input) where T : class
        {
            T? value = null;
            // --- Start ---
            if (input != null)
            {
                value = input;
            }
            // --- End ---
            return value;
        }
    }

    internal class TC_FUNC027_Generic_With_Constraints_Expected_Result
    {
        public T? Outer<T>(T? input) where T : class
        {
            T? value = null;
            // --- Start ---
            value = Value(input, value);
            // --- End ---
            return value;

            T? Value(T? input1, T? value1)
            {
                if (input1 != null)
                {
                    value1 = input1;
                }

                return value1;
            }
        }
    }
}