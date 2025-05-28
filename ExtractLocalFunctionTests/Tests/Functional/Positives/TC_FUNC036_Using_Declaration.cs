// TC_FUNC036: Extraction involving 'using declaration'
//
// Scenario:
// The selected code includes a 'using' declaration
// The resource is used within the selection
//
// Action:
// 1. Select the code block between "// --- Start ---" and "// --- End ---"
// 2. Invoke Extract Local Function (Ctrl+R, Ctrl+M => L => Enter)
// 3. In the Extract Local Function dialog select following options
//    - Return type: local variable
// 4. Confirm the refactoring
//
// Expected result:
// - The using declaration and its associated resource usage are moved into the local function
// - The local function correctly manages the resource lifetime
//
namespace ExtractLocalFunctionTests.Tests.Functional.Positives
{
    using System.IO;

    internal class TC_FUNC036_Using_Declaration_SourceCode
    {
        public string? Outer()
        {
            string? line;
            // --- Start ---
            using var reader = new StringReader("Hello\nWorld");
            line = reader.ReadLine();
            // --- End ---
            return line;
        }
    }

    internal class TC_FUNC036_Using_Declaration_Expected_Result
    {
        public string? Outer()
        {
            string? line;
            // --- Start ---
            line = Line();
            // --- End ---
            return line;

            string? Line()
            {
                using var reader = new StringReader("Hello\nWorld");
                line = reader.ReadLine();
                return line;
            }
        }
    }
}