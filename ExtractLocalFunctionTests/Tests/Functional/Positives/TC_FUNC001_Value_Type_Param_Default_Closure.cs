// TC_FUNC001: Functional - Value Type Parameter (Default Closure)

// Scenario:
// When a value type variable is read but not modified within the extracted block, and its parameter is NOT selected in the dialog, it should be captured by closure

// Action:
// 1. Select 'Console.WriteLine(x + 5);'
// 2. Invoke Extract Local Function (Ctrl+R, Ctrl+M => L => Enter)
// 3. In the dialog, ensure the 'x' parameter checkbox is UNCHECKED (default behavior)
// 4. Confirm the refactoring by hitting Enter or clicking Next

// Expected Result:
// The local function is named 'NewFunction', has no parameters, and accesses 'x' from outer scope

namespace ExtractLocalFunctionTests.Tests.Functional.Positives
{
    internal class TC_FUNC001_Value_Type_Param_Default_Closure_SourceCode
    {
        public void Method()
        {
            int x = 10;
            int y = 20;
            Console.WriteLine(x + y);
        }
    }
    internal class TC_FUNC001_Value_Type_Param_Default_Closure_Expected_Result
    {
        public void Method()
        {
            int x = 10;
            int y = 20;
            NewFunction();

            void NewFunction()
            {
                Console.WriteLine(x + y);
            }
        }
    }
}