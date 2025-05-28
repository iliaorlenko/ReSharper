// TC_FUNC007: Functional - Reference Type Parameter (Explicit Parameter, Internal State Modified)

// Scenario:
// When a reference type variable (list) has its internal state modified within the extracted block, and its parameter IS selected in the dialog,
// it should be passed as an explicit parameter

// Action:
// 1. Select 'list.Add("item1"); Console.WriteLine(list.Count);'
// 2. Invoke Extract Local Function (Ctrl+R, Ctrl+M => L => Enter)
// 3. In the dialog, ensure the 'list' parameter checkbox is CHECKED
// 4. Confirm the refactoring by hitting Enter or clicking Next

// Expected Result:
// The local function is named 'NewFunction', takes 'list' as a List<string> parameter, and the modification of 'listParam' inside the function affects the original 'list'

namespace ExtractLocalFunctionTests.Tests.Functional.Positives
{
    internal class TC_FUNC007_Ref_Type_Param_Internal_Modified_Explicit_Parameter_SourceCode
    {
        public void Method()
        {
            List<string> list = new List<string>();
            list.Add("item1");
            Console.WriteLine(list.Count);
        }
    }

    internal class TC_FUNC007_Ref_Type_Param_Internal_Modified_Explicit_Parameter_Expected_Result
    {
        public void Method()
        {
            List<string> list = new List<string>();
            NewFunction(list);

            void NewFunction(List<string> list1)
            {
                list1.Add("item1");
                Console.WriteLine(list1.Count);
            }
        }
    }
}