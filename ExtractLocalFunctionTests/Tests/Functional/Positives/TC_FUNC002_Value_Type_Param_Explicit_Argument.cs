// TC_FUNC002: Functional - Value Type Parameter (Explicit Argument)

// Scenario: When a value type variable is read but not modified within the extracted block, and its parameter IS selected in the dialog, it should be passed as an explicit argument

// Action:
// 1. Select 'Console.WriteLine(x + 5);'
// 2. Invoke Extract Local Function (Ctrl+R, Ctrl+M => L => Enter)
// 3. In the dialog, ensure the 'x' parameter checkbox IS CHECKED
// 4. Confirm the refactoring by hitting Enter or clicking Next

// Expected Result:
// The local function is named 'NewFunction', takes 'x' as an 'int' parameter, and the call site passes 'x'.

namespace ExtractLocalFunctionTests.Tests.Functional.Positives
{
    internal class TC_FUNC002_ValueTypeParamExplicitArgument_SourceCode
    {
        public void Method()
        {
            int x = 10;
            Console.WriteLine(x + 5);
        }
    }

    internal class TC_FUNC002_ValueTypeParamExplicitArgument_Expected_Result
    {
        public void Method()
        {
            int x = 10;
            NewFunction(x);
            void NewFunction(int i)
            {
                Console.WriteLine(i + 5);
            }
        }
    }
}