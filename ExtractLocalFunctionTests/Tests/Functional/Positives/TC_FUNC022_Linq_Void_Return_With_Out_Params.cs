// TC_FUNC022: LINQ extraction with void return and out parameters
//
// Scenario:
// A LINQ query is extracted, and its results are returned via 'out' parameters
//
// Action:
// 1. Select the code block between "// --- Start ---" and "// --- End ---"
// 2. Invoke Extract Local Function (Ctrl+R, Ctrl+M => L => Enter)
// 3. In the Extract Local Function dialog select following options
//    - Return type: <void>
//    - Parameters: all params are checked
// 4. Confirm the refactoring
//
// Expected result:
// - A new local function with a void return type is created
// - The local function has 'out' parameters for 'query' and 'evenNumbers'
// - The call site passes variables to these new 'out' parameters, receiving the query and the list
// - Param namings are ints, enumerable and evenNumbers1
//
namespace ExtractLocalFunctionTests.Tests.Functional.Positives
{
    using System.Collections.Generic;
    using System.Linq;

    internal class TC_FUNC022_Linq_Void_Return_With_Out_Params_SourceCode
    {
        public void Outer()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5, 6 };
            IEnumerable<int> query;
            IEnumerable<int> evenNumbers;
            // --- Start ---
            query = from num in numbers
                where num % 2 == 0
                select num;
            evenNumbers = query.ToList();
            // --- End ---
        }
    }

    internal class TC_FUNC022_Linq_Void_Return_With_Out_Params_Expected_Result
    {
        public void Outer()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5, 6 };
            IEnumerable<int> query;
            IEnumerable<int> evenNumbers;
            // --- Start ---
            NewFunction(numbers, out query, out evenNumbers);
            // --- End ---

            void NewFunction(List<int> ints, out IEnumerable<int> enumerable, out IEnumerable<int> evenNumbers1)
            {
                enumerable = from num in ints
                             where num % 2 == 0
                           select num;
                evenNumbers1 = enumerable.ToList();
            }
        }
    }
}
