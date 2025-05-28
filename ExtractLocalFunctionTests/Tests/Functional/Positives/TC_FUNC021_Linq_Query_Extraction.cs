// TC_FUNC021: Extraction of a LINQ query with inferred return
//
// Scenario:
// Extraction of a LINQ query where the result (a materialized list) is assigned
// to a variable that is then returned by the outer method
//
// Action:
// 1. Select the code block between "// --- Start ---" and "// --- End ---"
// 2. Invoke Extract Local Function (Ctrl+R, Ctrl+M => L => Enter)
// 3. In the Extract Local Function dialog select following options
//    - Return type: 'evenNumbers (local variable)' is selected
//    - Parameters: 'numbers' is checked
// 4. Confirm the refactoring
//
// Expected result:
// - The LINQ query and its materialization are extracted correctly into a new local function
// - The new function takes 'numbers' as a parameter
// - The local function returns the materialized list (IEnumerable<long>)
// - The call site assigns the result of the local function back to 'evenNumbers'
//
namespace ExtractLocalFunctionTests.Tests.Functional.Positives
{
    using System.Collections.Generic;
    using System.Linq;

    internal class TC_FUNC021_Linq_Query_SourceCode
    {
        public IEnumerable<long> Outer()
        {
            var numbers = new List<long> { 1, 2, 3, 4, 5, 6 };
            IEnumerable<long> evenNumbers;
            // --- Start ---
            var query = from num in numbers
                where num % 2 == 0
                select num;
            evenNumbers = query.ToList();
            // --- End ---
            return evenNumbers;
        }
    }

    internal class TC_FUNC021_Linq_Query_Expected_Result
    {
        public IEnumerable<long> Outer()
        {
            var numbers = new List<long> { 1, 2, 3, 4, 5, 6 };
            IEnumerable<long> evenNumbers;
            // --- Start ---
            evenNumbers = EvenNumbers(numbers);
            // --- End ---
            return evenNumbers;

            IEnumerable<long> EvenNumbers(List<long> longs)
            {
                var query = from num in longs
                    where num % 2 == 0
                    select num;
                evenNumbers = query.ToList();
                return evenNumbers;
            }
        }
    }
}