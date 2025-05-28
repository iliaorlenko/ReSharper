// TC_FUNC014: Functional - Code block inside void method is correctly extracted into a parameterless void function 

// Scenario:
// All variables within the selected code block are declared and used only within that selection
// Outer method has void return type

// Action:
// 1. Select the code block between "// --- Start ---" and "// --- End ---"
// 2. Invoke Extract Local Function (Ctrl+R, Ctrl+M => L => Enter)
// 3. In the Extract Local Function dialog select following options
//    - Return type: '<void>'
//    - Parameters: All variables are unchecked
// 4. Confirm the refactoring

// Expected Result:
// The generated function is simple, taking no parameters and returning void, as ReSharper correctly identifies that no data needs to be passed out

namespace ExtractLocalFunctionTests.Tests.Functional.Positives
{
    internal class TC_FUNC014_Void_Outer_Extract_Parameterless_Void_Function_SourceCode
    {
        public void Method()
        {
            // --- Start ---
            int value = 5;
            int result = 10;
            Console.WriteLine(value + result);
            // --- End ---
        }
    }

    internal class TC_FUNC014_Void_Outer_Extract_Parameterless_Void_Function_Expected_Result
    {
        public void Method()
        {
            // --- Start ---
            NewFunction();

            // --- End ---
            void NewFunction()
            {
                int value = 5;
                int result = 10;
                Console.WriteLine(value + result);
            }
        }
    }
}