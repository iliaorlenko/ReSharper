// TC_FUNC023: LINQ extraction with multiple values tuple return
//
// Scenario:
// A LINQ query and its materialized result are extracted and returned together as a tuple
//
// Action:
// 1. Select the code block between "// --- Start ---" and "// --- End ---"
// 2. Invoke Extract Local Function (Ctrl+R, Ctrl+M => L => Enter)
// 3. In the Extract Local Function dialog select following options
//    - Return type: <Multiple values>
//    - Parameters: 'numbers' (checked). 'query' and 'evenNumbers' should be identified as outputs for the tuple.
// 4. Confirm the refactoring
//
// Expected result:
// - A new local function is created that returns a tuple (e.g., (IEnumerable<int> query, IEnumerable<int> list))
// - The call site uses tuple deconstruction to assign the results to 'query' and 'evenNumbers'
//
// !!!BUG!!! Variables renamed and cannot be found

namespace ExtractLocalFunctionTests.Tests.Functional.Positives
{
    using System.Collections.Generic;
    using System.Linq;

    internal class TC_FUNC023_Linq_Multiple_Values_Tuple_Return_SourceCode
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

    internal class TC_FUNC023_Linq_Multiple_Values_Tuple_Return_Expected_Result
    {
        public void Outer()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5, 6 };
            IEnumerable<int> query;
            IEnumerable<int> evenNumbers;
            // --- Start ---
            (query, evenNumbers) = NewFunction(numbers);
            // --- End ---

            (IEnumerable<int> query, IEnumerable<int> evenNumbers) NewFunction(List<int> ints)
            {
                query = from num in ints
                    where num % 2 == 0
                    select num;
                evenNumbers = query.ToList();
                return (query, evenNumbers);
            }
        }
    }
}
