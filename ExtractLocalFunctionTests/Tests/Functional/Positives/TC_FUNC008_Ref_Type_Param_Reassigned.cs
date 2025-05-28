// TC_FUNC008: Functional - Reassign Reference Type Parameter

// Scenario:
// If a reference type variable is reassigned within the extracted block and that reassignment needs to be visible in the outer scope, it must be passed as 'ref' or 'out'

// Action:
// 1. Select 'list = new List<string> { "new" }; list.Add("item"); Console.WriteLine(list.Count);'
// 2. Invoke Extract Local Function (Ctrl+R, Ctrl+M => L => Enter)
// 3. Confirm the refactoring by hitting Enter or clicking Next

// Expected Result:
// The local function is named 'NewFunction', has no parameters, and modifies 'list' via closure, reflecting the reassignment in the outer scope

namespace ExtractLocalFunctionTests.Tests.Functional.Positives
{
    internal class TC_FUNC008_Ref_Type_Param_Reassigned_SourceCode
    {
        public void Method()
        {
            List<string> list = null;
            list = new List<string>();
            list.Add("item");
            Console.WriteLine(list.Count);
        }
    }

    internal class TC_FUNC008_Ref_Type_Param_Reassigned_Expected_Result
    {
        public void Method()
        {
            List<string> list = null;
            NewFunction();

            void NewFunction()
            {
                list = new List<string>();
                list.Add("item");
                Console.WriteLine(list.Count);
            }
        }
    }
}