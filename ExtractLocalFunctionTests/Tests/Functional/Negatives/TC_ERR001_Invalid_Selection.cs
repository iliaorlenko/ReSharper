// TC_ERR001: Invalid Code Selection - Half a line
//
// Scenario:
// Attempt to extract a local function from an invalid code selection (half a line)
//
// Action:
// 1. Select "Console.WriteLine" from 'Console.WriteLine("Hello, World!");'
// 2. Invoke Extract Local Function (e.g., Ctrl+R, Ctrl+M, L) !!!BUG!!!
//
// Expected Result:
// A message "The key combination (CTRL+R, CTRL+M) is bound to command (ReSharper_ExtractMethod) which is not currently available." should appear in the status bar
//
// 3. Select "("Hello, World!");" from 'Console.WriteLine("Hello, World!");'
// 4. Invoke Extract Local Function (e.g., Ctrl+R, Ctrl+M, L)
//
// Expected Result:
// A message "The key combination (CTRL+R, CTRL+M) is bound to command (ReSharper_ExtractMethod) which is not currently available." should appear in the status bar

namespace ExtractLocalFunctionTests.Tests.Functional.Negatives
{
    using System;

    internal class TC_ERR001_Invalid_Selection
    {
        public void Method()
        {
            Console.WriteLine("Hello, World!");
        }
    }
}