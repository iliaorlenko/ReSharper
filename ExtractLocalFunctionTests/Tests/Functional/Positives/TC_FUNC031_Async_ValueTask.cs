// TC_FUNC031: Async method returning ValueTask, extracting async code
//
// Scenario:
// An async method returns a ValueTask<int>
// The selection contains an 'await' operation and calculates the integer result
//
// Action:
// 1. Select the code block between "// --- Start ---" and "// --- End ---"
// 2. Invoke Extract Local Function (Ctrl+R, Ctrl+M => L => Enter)
// 3. In the Extract Local Function dialog select following options
//    - Parameters: 'input'
//    - Return type: async ValueTask<int>
// 4. Confirm the refactoring
//
// Expected result:
// - The extracted local function is 'async ValueTask<int>'
// - The outer method returns ValueTask
//
// !!!BUG!!! Instead of returning result directly, it assigns it first (to an invalid variable) and then tries to return
namespace ExtractLocalFunctionTests.Tests.Functional.Positives
{
    using System.Threading.Tasks;

    internal class TC_FUNC031_Async_ValueTask_SourceCode
    {
        public async ValueTask<int> OuterAsync(int input)
        {
            // --- Start ---
            await Task.Delay(5);
            int result = input * 2;
            return result;
            // --- End ---
        }
    }

    internal class TC_FUNC031_Async_ValueTask_Expected_Result
    {
        public async ValueTask<int> OuterAsync(int input)
        {
            // --- Start ---
            return await Result(input);

            // --- End ---
            async ValueTask<int> Result(int i)
            {
                await Task.Delay(5);
                int result = i * 2;
                return result;
            }
        }
    }
}