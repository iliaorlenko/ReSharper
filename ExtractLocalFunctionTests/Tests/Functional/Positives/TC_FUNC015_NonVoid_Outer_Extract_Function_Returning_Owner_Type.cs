// TC_FUNC015: '<Owner Return>' option correctly uses the parent method's return

// Scenario:
// 
// Description:
// One parameter is passed to the outer method
// One variable is declared in the selection
// Outer method has int return type

// Action:
// 1. Select the code block from "// --- Selection Starts ---" to "// --- Selection Ends ---".
// 2. Invoke Extract Local Function (Ctrl+R, Ctrl+M => L => Enter)
// 3. In the Extract Local Function dialog select following options
//    - Return type: Select '<Owner Return>'
//    - Parameters: No parameters selected
// 4. Confirm the refactoring.

// Expected result:
// Extracted function returns the same value as outer method

namespace ExtractLocalFunctionTests.Tests.Functional.Positives
{
    internal class TC_FUNC015_Owner_Return_Option_SourceCode
    {
        public int Outer(int value)
        {
            // --- Selection Starts ---
            int result = value * 2;
            return result;
            // --- Selection Ends ---
        }
    }

    internal class TC_FUNC015_Owner_Return_Option_Expected_Result
    {
        public int Outer(int value)
        {
            // --- Selection Starts ---
            return Result();

            // --- Selection Ends ---
            int Result()
            {
                int result = value * 2;
                return result;
            }
        }
    }
}