// TC_FUNC019: Extraction from an existing nested local function
//
// Scenario:
// The code selection is within an already existing local function
// This tests the ability to create a nested local function
//
// Action:
// 1. Select the code block between "// --- Start ---" and "// --- End ---" inside 'ExistingLocalFunction'
// 2. Invoke Extract Local Function (Ctrl+R, Ctrl+M => L => Enter)
// 3. In the Extract Local Function dialog select following options
//    - Parameters: 'data' should be detected
//    - Return type: Should be inferred
// 4. Confirm the refactoring
//
// Expected result:
// - A new local function is created inside the 'ExistingLocalFunction'
// - The selected code is moved into this new inner local function
//
namespace ExtractLocalFunctionTests.Tests.Functional.Positives
{
    internal class TC_FUNC019_Extraction_From_Nested_Local_Function_SourceCode
    {
        public int Outer(int value)
        {
            return ExistingLocalFunction(value);

            int ExistingLocalFunction(int data)
            {
                int result;
                // --- Start ---
                result = data * 10;
                // --- End ---
                return result + data;
            }
        }
    }

    internal class TC_FUNC019_Extraction_From_Nested_Local_Function_Expected_Result
    {
        public int Outer(int value)
        {
            return ExistingLocalFunction(value);

            int ExistingLocalFunction(int data)
            {
                int result;
                // --- Start ---
                result = Result(data);
                // --- End ---
                return result + data;
            }

            int Result(int data)
            {
                int result;
                result = data * 10;
                return result;
            }
        }
    }
}