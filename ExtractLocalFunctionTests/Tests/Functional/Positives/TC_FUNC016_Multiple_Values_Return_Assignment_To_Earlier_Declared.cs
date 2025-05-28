// TC_FUNC016: Validate ideal tuple return when modifying external vars and using explicit input

// Scenario:
// A block of code contains assignment to variables declared earlier
// Return type is <Multiple Values>

// Action:
// 1. Select the block inside "// --- Start ---" and "// --- End ---"
// 2. Invoke Extract Local Function (Ctrl+R, Ctrl+M => L => Enter)
// 3. In the Extract Local Function dialog select following options
//    - Return type: Select '<Multiple values'
//    - Parameters: Both parameters are checked
// 4. Confirm the refactoring

// Expected Result:
// Extracted tuple contains variables names initially declared in a code before extraction

namespace ExtractLocalFunctionTests.Tests.Functional.Positives
{
    internal class TC_FUNC016_Multiple_Values_Return_Assignment_To_Earlier_Declared_SourceCode
    {
        public void Outer()
        {
            int value = 1;
            int result = 2;

            value = 10;
            result = 20;
        }
    }

    internal class TC_FUNC016_Multiple_Values_Return_Assignment_To_Earlier_Declared_Expected_Result
    {
        public void Outer()
        {
            int value = 10;
            int result = 20;

            (value, result) = NewFunction();


            (int value, int result) NewFunction()
            {
                int value1 = 1;
                int result1 = 2;
                return (value1, result1);
            }
        }
    }
}