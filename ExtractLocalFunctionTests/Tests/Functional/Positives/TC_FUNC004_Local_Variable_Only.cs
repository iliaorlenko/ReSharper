// TC_FUNC004: Functional - Local Variable Declared and Used Locally

// Scenario:
// Variables declared and used exclusively within the selected block should remain local to the extracted function and not become parameters

// Action:
// 1. Select 'string message = "Hello"; Console.WriteLine(message + " World");'
// 2. Invoke Extract Local Function (Ctrl+R, Ctrl+M => L => Enter)
// 3. Confirm the refactoring by hitting Enter or clicking Next

// Expected Result:
// The local function is named 'NewFunction' and has no parameters. The variable remains local to the new function

namespace ExtractLocalFunctionTests.Tests.Functional.Positives
{
    internal class TC_FUNC004_Local_Variable_Only_SourceCode
    {
        public void Method()
        {
            string message = "Hello";
            Console.WriteLine(message + " World");
        }
    }

    internal class TC_FUNC004_Local_Variable_Only_Expected_Result
    {
        public void Method()
        {
            NewFunction();

            void NewFunction()
            {
                string message = "Hello";
                Console.WriteLine(message + " World");
            }
        }
    }
}