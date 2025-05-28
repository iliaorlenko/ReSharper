// TC_FUNC020: Correctly extracts assignment to an enclosing method's out parameter as a return value
//
// Scenario:
// A user extracts a line that assigns a value to the enclosing method's 'out' parameter
// The user intends for the new local function to return this value
//
// Action:
// 1. Select the code block between "// --- Start ---" and "// --- End ---"
// 2. Invoke Extract Local Function (Ctrl+R, Ctrl+M => L => Enter)
// 3. In the Extract Local Function dialog select following options
//    - Return type: Select 'output (parameter)' from the dropdown
//    - Parameters: 'input' is checked
// 4. Confirm the refactoring
//
// Expected result:
// - A new local function is created that takes 'input' as a parameter
// - The local function calculates and returns the value originally assigned to the 'output' variable
// - The call site assigns the result of the local function to the 'output' variable
//
// !!!BUG!!! Tries to assign to enclosing method's out param
namespace ExtractLocalFunctionTests.Tests.Functional.Positives
{
    internal class TC_FUNC020_Out_Param_Of_Outer_Assigned_In_Selection_SourceCode
    {
        public void Outer(int input, out int output)
        {
            // --- Start ---
            output = input * 2;
            // --- End ---
        }
    }

    internal class TC_FUNC020_Out_Param_Of_Outer_Assigned_In_Selection_Expected_Result
    {
        public void Outer(int input, out int output)
        {
            // --- Start ---
            output = NewFunction(input);
            // --- End ---

            int NewFunction(int input1)
            {
                return input1 * 2;
            }
        }
    }
}