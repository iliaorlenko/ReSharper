// TC_FUNC035: Extraction of switch statement with simple string values
//
// Scenario:
// The selected code includes a classic switch statement used to assign a value
// The switch statement uses string variables from the outer scope
//
// Action:
// 1. Select the code block between "// --- Start ---" and "// --- End ---"
// 2. Invoke Extract Local Function (Ctrl+R, Ctrl+M => L => Enter)
// 3. In the Extract Local Function dialog select following options
//    - Parameters: all params are checked
//    - Return type: local variable
// 4. Confirm the refactoring
//
// Expected result:
// - The switch statement is extracted into a local function
// - The local function correctly uses the input string parameters
// !!!BUG!!! Same bug with namings (first string renamed to s, following - by adding 1 to original name)
namespace ExtractLocalFunctionTests.Tests.Functional.Positives
{
    internal class TC_FUNC035_Switch_Statement_Simple_Strings_SourceCode
    {
        public string Outer(string value, string another)
        {
            string result;
            // --- Start ---
            switch (value)
            {
                case "string value":
                    result = "string value new";
                    break;
                case "string another":
                    result = "string another new: " + another;
                    break;
                default:
                    result = "string result new";
                    break;
            }
            // --- End ---
            return result;
        }
    }

    internal class TC_FUNC035_Switch_Statement_Simple_Strings_Expected_Result
    {
        public string Outer(string value, string another)
        {
            string result;
            // --- Start ---
            result = Result(value, another);
            // --- End ---
            return result;

            string Result(string value1, string another1)
            {
                switch (value1)
                {
                    case "string value":
                        result = "string value new";
                        break;
                    case "string another":
                        result = "string another new: " + another1;
                        break;
                    default:
                        result = "string result new";
                        break;
                }

                return result;
            }
        }
    }
}
