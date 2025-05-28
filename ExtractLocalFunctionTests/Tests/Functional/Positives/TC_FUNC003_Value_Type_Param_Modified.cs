// TC_FUNC003: Functional - Modified external variable is captured by closure by default

// Scenario:
// When a value type variable is modified within the extracted block, and its parameter is not selected in the dialog,
// it should be captured by closure, and the modification should affect the original variable

// Action:
// 1. Select the code block between "// --- Start ---" and "// --- End ---"
// 2. Invoke Extract Local Function (Ctrl+R, Ctrl+M => L => Enter)
// 3. In the dialog, confirm the default settings are:
//    - Return type: 'void'
//    - Parameters: The checkbox for 'x' is unchecked
// 4. Confirm the refactoring by hitting Enter or clicking Next

// Expected Result:
// The local function is named 'NewFunction', has no parameters, and modifies 'x' via closure, reflecting changes in the outer scope

namespace ExtractLocalFunctionTests.Tests.Functional.Positives
{
    internal class TC_FUNC003_Value_Type_Param_Modified_Default_Closure_SourceCode
    {
        public void Method()
        {
            int x = 20;
            
            // --- Start ---
            x += 5;
            Console.WriteLine(x);
            // --- End ---
        }
    }

    internal class TC_FUNC003_Value_Type_Param_Modified_Default_Closure_Expected_Result
    {
        public void Method()
        {
            int x = 20;

            // --- Start ---
            NewFunction();

            // --- End ---
            void NewFunction()
            {
                x += 5;
                Console.WriteLine(x);
            }
        }
    }
}