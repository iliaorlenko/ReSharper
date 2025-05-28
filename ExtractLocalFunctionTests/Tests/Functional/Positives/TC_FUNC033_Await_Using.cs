// TC_FUNC033: Extraction of code using 'await using'
//
// Scenario:
// The selected code block contains an 'await using' statement for an IAsyncDisposable resource
//
// Action:
// 1. Select the code block between "// --- Start ---" and "// --- End ---"
// 2. Invoke Extract Local Function (Ctrl+R, Ctrl+M => L => Enter)
// 3. In the Extract Local Function dialog select following options
//    - Return type: <void>
// 4. Confirm the refactoring
//
// Expected result:
// - The 'await using' block is extracted into an async local function
//
namespace ExtractLocalFunctionTests.Tests.Functional.Positives
{
    using System.Threading.Tasks;

    internal class TC_FUNC033_Await_Using_SourceCode
    {
        public async Task OuterAsync()
        {
            // --- Start ---
            await using (var stream = new MemoryStream())
            {
                await stream.FlushAsync();
            }
            // --- End ---
        }
    }

    internal class TC_FUNC033_Await_Using_Expected_Result
    {
        public async Task OuterAsync()
        {
            // --- Start ---
            await NewFunction();
            // --- End ---

            async Task NewFunction()
            {
                await using (var stream = new MemoryStream())
                {
                    await stream.FlushAsync();
                }
            }
        }
    }
}