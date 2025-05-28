// TC_FUNC024: Handling of Nullable Reference Types
//
// Scenario:
// The project has Nullable Reference Types enabled
// The selection uses nullable and non-nullable strings from the outer scope and returns a nullable string
//
// Action:
// 1. Select the code block between "// --- Start ---" and "// --- End ---"
// 2. Invoke Extract Local Function (Ctrl+R, Ctrl+M => L => Enter)
// 3. In the Extract Local Function dialog select following options
//    - Parameters: all params are checked
//    - Return type: local variable
// 4. Confirm the refactoring
//
// Expected result:
// - Nullable annotations are preserved/inferred correctly for parameters and return type in the local function
//
#nullable enable
namespace ExtractLocalFunctionTests.Tests.Functional.Positives
{
    internal class TC_FUNC024_NullableRefType_Handling_SourceCode
    {
        public string? Outer(string? nullableInput, string nonNullableInput)
        {
            string? result;
            // --- Start ---
            result = Result(nullableInput, nonNullableInput);
            // --- End ---
            return result;

            string? Result(string? s, string nonNullableInput1)
            {
                if (s != null)
                {
                    result = s.ToUpper() + nonNullableInput1;
                }
                else
                {
                    result = null;
                }

                return result;
            }
        }
    }

    internal class TC_FUNC024_NullableRefType_Handling_Expected_Result
    {
        public string? Outer(string? nullableInput, string nonNullableInput)
        {
            string? result;
            // --- Start ---
            result = Result(nullableInput, nonNullableInput);
            // --- End ---
            return result;

            string? Result(string? s, string nonNullableInput1)
            {
                if (s != null)
                {
                    result = s.ToUpper() + nonNullableInput1;
                }
                else
                {
                    result = null;
                }

                return result;
            }
        }
    }
}
#nullable disable
