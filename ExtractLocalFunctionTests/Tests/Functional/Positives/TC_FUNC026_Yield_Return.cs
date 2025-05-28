// TC_FUNC026: Extraction of 'yield return' statements for an iterator
//
// Scenario:
// The selection contains 'yield return' statements within a loop
// The outer method returns IEnumerable<T>, and the user selects '<Owner Return>'
//
// Action:
// 1. Select the code block between "// --- Start ---" and "// --- End ---"
// 2. Invoke Extract Local Function (Ctrl+R, Ctrl+M => L => Enter)
// 3. In the Extract Local Function dialog select following options
//    - Return type: Select '<Owner yield return>'
//    - Parameters: 'count' is checked
// 4. Confirm the refactoring
//
// Expected result:
// - The extracted local function becomes a valid iterator method using 'yield return'
// - The return type of the local function is correctly set to IEnumerable<int>
//
// !!!BUG!!! minor: it is better to return function result immediately instead of yield returning it within foreach

namespace ExtractLocalFunctionTests.Tests.Functional.Positives
{
    using System.Collections.Generic;

    internal class TC_FUNC026_Yield_Return_SourceCode
    {
        public IEnumerable<int> Outer(int count)
        {
            // --- Start ---
            for (int i = 0; i < count; i++)
            {
                if (i % 2 == 0)
                {
                    yield return i * 10;
                }
            }
            // --- End ---
        }
    }

    internal class TC_FUNC026_Yield_Return_Expected_Result
    {
        public IEnumerable<int> Outer(int count)
        {
            // --- Start ---
            return Enumerable(count);
            // --- End ---

            IEnumerable<int> Enumerable(int count1)
            {
                for (int i = 0; i < count1; i++)
                {
                    if (i % 2 == 0)
                    {
                        yield return i * 10;
                    }
                }
            }
        }
    }
}