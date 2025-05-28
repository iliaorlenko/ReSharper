// TC_FUNC030: Async method with try-catch-finally, extracting part of try block
//
// Scenario:
// An async method contains a try-catch-finally block
// The selection is a part of the 'try' block that includes an 'await' operation
//
// Action:
// 1. Select the code block between "// --- Start ---" and "// --- End ---"
// 2. Invoke Extract Local Function (Ctrl+R, Ctrl+M => L => Enter)
// 3. In the Extract Local Function dialog select following options
//    - Return type: void
// 4. Confirm the refactoring
//
// Expected result:
// - The selected async code is extracted into an async local function
// - The call to the local function is awaited within the original 'try' block
//
namespace ExtractLocalFunctionTests.Tests.Functional.Positives
{
    using System;
    using System.Threading.Tasks;

    internal class TC_FUNC030_Async_Try_Catch_SourceCode
    {
        public async Task OuterAsync()
        {
            try
            {
                // --- Start ---
                await Task.Delay(10);
                // --- End ---
            }
            catch (Exception)
            {
                // Handle error
            }
            finally
            {
                // Cleanup
            }
        }
    }

    internal class TC_FUNC030_Async_Try_Catch_Expected_Result
    {
        public async Task OuterAsync()
        {
            try
            {
                // --- Start ---
                await NewFunction();
                // --- End ---
            }
            catch (Exception)
            {
                // Handle error
            }
            finally
            {
                // Cleanup
            }

            async Task NewFunction()
            {
                await Task.Delay(10);
            }
        }
    }
}