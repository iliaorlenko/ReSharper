// TC_FUNC005: Functional - Reference Type Parameter (Default Closure, Read-Only)

// Scenario:
// When a reference type variable is read but not modified within the extracted block, and its parameter is NOT selected in the dialog, it should be captured by closure

// Action:
// 1. Select 'Console.WriteLine(list.Count);'
// 2. Invoke Extract Local Function (Ctrl+R, Ctrl+M => L => Enter)
// 3. In the dialog, ensure the 'list' parameter checkbox is UNCHECKED (default behavior)
// 4. Confirm the refactoring by hitting Enter or clicking Next

// Expected Result:
// The local function is named 'NewFunction', has no parameters, and accesses 'list' via closure

namespace ExtractLocalFunctionTests.Tests.Functional.Positives
{
    internal class TC_FUNC005_Ref_Type_Param_Default_Closure_SourceCode
    {
        public void Method()
        {
            List<string> list = new List<string> { "a", "b" };
            Console.WriteLine(list.Count);
        }
    }

    internal class TC_FUNC005_Ref_Type_Param_Default_Closure_Expected_Result
    {
        public void Method()
        {
            List<string> list = new List<string> { "a", "b" };
            NewFunction();

            void NewFunction()
            {
                Console.WriteLine(list.Count);
            }
        }
    }
}