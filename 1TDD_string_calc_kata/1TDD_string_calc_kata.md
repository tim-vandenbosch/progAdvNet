# PXL
## Programming Advanced NET
### 1TDD_string_calc_kata -> Test Driven Development -*unfinished*

#### Basic
1. simple string calculator with a method *int Add(string numbers)*  
the method can take 0,1 or 2 numbers, and will return their sum (for an empty string it will return 0).  
For example "" or "1" or "1,2"
2. Start with the simplest test case of an empty string and move to 1 and two numbers.
- Remember to solve things as simply as possible so that you force yourself to write tests you did not think about.
- Remember to refactor after each passing test.

#### Advanced
1.	Allow the Add method to handle an unknown amount of numbers.
2.	If the input contains a part that is not a number or comma, throw an exception “Invalid number”.  
The invalid number should be passed in the exception message.
3.	Allow the Add method to handle new lines between numbers (instead of commas).  
The following input is ok: "1\n2,3" (will equal 6). The following input is NOT ok: "1,\n2".
4.	Support different delimiters. To change a delimiter, the beginning of the string will contain a separate line  
that looks like this: //[delimiter]\n[numbers...], for example //;\n1;2 should return three where the default delimiter is ; .  
The first line is optional. all existing scenarios should still be supported.
5.	Calling Add with a negative number should throw an exception "negatives not allowed" - and the negative that was passed.  
If there are multiple negatives, show all of them in the exception message
