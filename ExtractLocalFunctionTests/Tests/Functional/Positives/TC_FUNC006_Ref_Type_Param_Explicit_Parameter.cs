// TC_FUNC006: Functional - Reference Type Parameter (Explicit Parameter, Read-Only)

// Scenario:
// When a reference type variable is read but not modified within the extracted block, and its parameter IS selected in the dialog, it should be passed as an explicit parameter.

// Action:
// 1. Select 'Console.WriteLine(list.Count);'
// 2. Invoke Extract Local Function (Ctrl+R, Ctrl+M => L => Enter)
// 3. In the dialog, ensure the 'list' parameter checkbox is CHECKED
// 4. Confirm the refactoring by hitting Enter or clicking Next

// Expected Result:
// The local function is named 'NewFunction', takes 'list' as a List<string> parameter, and uses this parameter

namespace ExtractLocalFunctionTests.Tests.Functional.Positives
{
    internal class TC_FUNC006_Ref_Type_Param_Explicit_Parameter_SourceCode
    {
        public void Method()
        {
            List<string> list = new List<string> { "a", "b" };
            Console.WriteLine(list.Count);
        }
    }

    internal class TC_FUNC006_Ref_Type_Param_Explicit_Parameter_Expected_Result
    {
        public void Method()
        {
            List<string> list = new List<string> { "a", "b" };
            NewFunction(list);

            void NewFunction(List<string> list1)
            {
                Console.WriteLine(list1.Count);
            }
        }
    }
}