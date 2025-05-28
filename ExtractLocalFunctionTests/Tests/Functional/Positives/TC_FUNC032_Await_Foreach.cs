// TC_FUNC032: Extraction of code using 'await foreach'
//
// Scenario:
// The selected code block contains an 'await foreach' loop to consume an IAsyncEnumerable
//
// Action:
// 1. Select the code block between "// --- Start ---" and "// --- End ---"
// 2. Invoke Extract Local Function (Ctrl+R, Ctrl+M => L => Enter)
// 3. In the Extract Local Function dialog select following options
//    - Parameters: 'asyncStream'
//    - Return type: async Task<int>
// 4. Confirm the refactoring
//
// Expected result:
// - The 'await foreach' loop is extracted into an async local function
// - The local function processes the stream and returns a result (e.g. sum)
//
// - !!!BUG!!! Extracted function is not async

namespace ExtractLocalFunctionTests.Tests.Functional.Positives
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    internal class TC_FUNC032_Await_Foreach_SourceCode
    {
        public async Task<int> OuterAsync(IAsyncEnumerable<int> asyncStream)
        {
            int sum = 0;
            // --- Start ---
            await foreach (var item in asyncStream)
            {
                sum += item;
            }
            // --- End ---
            return sum;
        }
    }

    internal class TC_FUNC032_Await_Foreach_Expected_Result
    {
        public async Task<int> OuterAsync(IAsyncEnumerable<int> asyncStream)
        {
            int sum = 0;
            // --- Start ---
            sum = await Sum(asyncStream);
            // --- End ---
            return sum;

            async Task<int> Sum(IAsyncEnumerable<int> asyncEnumerable)
            {
                await foreach (var item in asyncEnumerable)
                {
                    sum += item;
                }

                return sum;
            }
        }
    }
}