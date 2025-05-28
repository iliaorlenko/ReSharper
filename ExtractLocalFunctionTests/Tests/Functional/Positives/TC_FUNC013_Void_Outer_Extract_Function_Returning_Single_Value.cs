// TC_FUNC013: Functional - A code block inside void method is correctly extracted into a function that returns a single output value

// Scenario:
// A variable is declared and initialized inside the selected block
// Its value is then read by code outside the selection
// Another variable has its entire lifecycle within the selection
// Outer method has void return type

// Action:
// 1. Select the code block between "// --- Start ---" and "// --- End ---"
// 2. Invoke Extract Local Function (Ctrl+R, Ctrl+M => L => Enter)
// 3. In the Extract Local Function dialog select following options
//    - Return type: 'varNeededLater (local variable)'
//    - Parameters: The checkbox for 'varNotNeededLater' is unchecked
// 4. Confirm the refactoring

// Expected Result:
// The generated function returns the value of 'varNeededLater'
// 'varNotNeededLater' becomes a standard local variable inside the new function

namespace ExtractLocalFunctionTests.Tests.Functional.Positives
{
    internal class TC_FUNC013_Extract_Function_Returning_Single_Value_SourceCode
    {
        public void Method()
        {
            // --- Start ---
            int varNeededLater = 1;
            varNeededLater++;

            int varNotNeededLater = 10;
            varNotNeededLater--;
            Console.WriteLine($"Internal value: {varNotNeededLater}");
            // --- End ---

            Console.WriteLine($"Final value: {varNeededLater}");
        }
    }

    internal class TC_FUNC013_Extract_Function_Returning_Single_Value_Expected_Result
    {
        public void Method()
        {
            // --- Start ---
            var varNeededLater = VarNeededLater();
            // --- End ---

            Console.WriteLine($"Final value: {varNeededLater}");

            int VarNeededLater()
            {
                int i = 1;
                i++;

                int varNotNeededLater = 10;
                varNotNeededLater--;
                Console.WriteLine($"Internal value: {varNotNeededLater}");
                return i;
            }
        }
    }
}