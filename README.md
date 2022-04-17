# Expression Calculator

Is a Calculator which able to transform the string input and calculate the value with Math operators “ + - * / “ and with brackets “ ( ) ”.

## How to do it?

1.	Prepare 2 stack which is **Math Operator Stack** and **Values Stack**.
    -	**Math Operator Stack** stores +, -, *, /, (, and )
    -	**Values Stack** stores numbers in double type.
2.	Convert the string input into string array by splitting the spaces
3.	Loop the string array 
    -	If element is number, put into **Values Stack**
    -	If element is operator,
        -	If current operator is highest priority among the operators in **Math Operator Stack**, push into **Math Operator Stack**
        -	Else, 
            -	Pop out 2 Values and 1 Operator and calculate it.
            -	Push the value back to **Values Stack**.
            -	Continue step (1) if current operator is not highest priority among the operators in **Math Operator Stack**.
            -	Push current operator into **Math Operator Stack**
    -	If element is open bracket, push into Operator Stack
    -	If element is closed bracket, 
        -	Pop out 2 Values and 1 Operator and calculate it
        -	Push the value into **Values Stack**
        -	Continue step (1) until found the next operator in **Math Operator Stack** is open bracket.
        -	Pop out the Open bracket
4.	Loop the Math Operator Stack,
    -	Pop out 2 Values and 1 Operator and calculate it.
    -	Push the value back to **Values Stack**
5.	Left last Value in **Values Stack** will be the final answer

