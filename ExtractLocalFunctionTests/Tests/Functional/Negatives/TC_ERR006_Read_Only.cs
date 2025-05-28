// TC_ERR006: Invalid Code Selection - Read-Only File

// Scenario:
// Attempt to extract a local function from a read-only file

// Action:
// 1. Open a C# file that is set to read-only
// 2. Select 'Console.WriteLine("Read-only file test");'
// 3. Invoke Extract Local Function (e.g., Ctrl+R, Ctrl+M, L)

// Expected Result:
// A clear message indicates the file is read-only and suggests to either cancel or make file as writable

namespace ExtractLocalFunctionTests.Tests.Functional.Negatives
{
    using System;

    internal class TC_ERR006_Read_Only
    {
        public void Method()
        {
            Console.WriteLine("Read-only file test");
        }
    }
}
