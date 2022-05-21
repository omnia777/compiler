using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication3.Models;
namespace WebApplication3.Services
{
    public class Compiler
    {

        static List<string> Condition = new List<string>()
            {
                "If",
                "Else"
            };
        static List<string> Integer = new List<string>()
            {
                "Iow"
            };
        static List<string> SInteger = new List<string>()
            {
                "SIow"
            };
        static List<string> Character = new List<string>()
            {
                "Chlo"
            };
        static List<string> String = new List<string>()
            {
                "Chain"
            };
        static List<string> Float = new List<string>()
            {
                "Iowf"
            };
        static List<string> SFloat = new List<string>()
            {
                "SIowf"
            };
        static List<string> Void = new List<string>()
            {
                "Worthless"
            };
        static List<string> Loop = new List<string>()
            {
                "Loopwhen",
                "Iteratewhen"
            };
        static List<string> Return = new List<string>()
            {
                "Turnback"
            };
        static List<string> Break = new List<string>()
            {
                "Stop"

            };
        static List<string> Struct = new List<string>()
            {
                "Loli"
            };
        static List<string> ArithmeticOperation = new List<string>()
            {
                "+",
                "-",
                "*",
                "/"
            };

        static List<string> LogicOperators = new List<string>()
            {
                "&",
                "|",
                "~"
            };
        static List<string> relationalOperator = new List<string>()
            {
                "<",
                ">",
                "!"
            };
        static List<string> AssignmentOperators = new List<string>()
            {
                "="
            };
        static List<string> AccessOperator = new List<string>()
            {
                "->"
            };
        static List<string> Braces = new List<string>()
            {
                "{",
                "}",
                "[",
                "]",
                "(",
                ")"
            };
        static List<string> QuaotationMark = new List<string>()
            {
                "\"",
                "'"
            };


        static List<string> Inclusion = new List<string>()
            {
                "Include"
            };
        static List<string> Separator = new List<string>()
            {
                ";"
            };
        public static int NumOfError = 0;
        public static int Line = 1;
        private static IDictionary<string, List<string>> keywords = new Dictionary<string, List<string>>()
        {

            {"Condition",Condition},
            {"Integer",Integer},
            {"SInteger",SInteger},
            {"Character",Character},
            {"String",String},
            {"Float",Float},
            {"SFloat",SFloat},
            {"Void",Void},
            {"Loop",Loop},
            {"Return",Return},
            {"Break",Break},
            {"Struct",Struct},
            {"Arithmetic Operation",ArithmeticOperation},
            {"Logic operators",LogicOperators},
            {"relational operator",relationalOperator},
            {"Assignment operator",AssignmentOperators},
            {"Access operator",AccessOperator},
            {"Braces",Braces},
            {"Quaotation Mark",QuaotationMark},
            {"Inclusion",Inclusion},
            {"Separator", Separator}
        };
        private static string check_reserved(string y)
        {
            if (y == keywords["Condition"][0])
            {
                return "Condition";
            }
            if (y == keywords["Condition"][1])
            {
                return "Condition";
            }
            if (y == keywords["Integer"][0])
            {

                return "Integer";

            }
            if (y == keywords["SInteger"][0])
            {
                return "SInteger";
            }
            if (y == keywords["Character"][0])
            {
                return "Character";
            }
            if (y == keywords["String"][0])
            {
                return "String";
            }
            if (y == keywords["Float"][0])
            {
                return "Float";
            }
            if (y == keywords["SFloat"][0])
            {
                return "SFloat";
            }
            if (y == keywords["Void"][0])
            {
                return "Void";
            }
            //loop
            if (y == keywords["Loop"][0])
            {
                return "Loop";
            }
            if (y == keywords["Loop"][1])
            {
                return "Loop";
            }
            if (y == keywords["Return"][0])
            {
                return "Return";
            }
            if (y == keywords["Break"][0])
            {
                return "Break";
            }
            if (y == keywords["Struct"][0])
            {
                return "Struct";
            }

            if (y == keywords["Inclusion"][0])
            {
                return "Inclusion";
            }

            return "Identifier";
        }
        private static bool isArithmeticOperation(char s)
        {
            foreach (var i in keywords["Arithmetic Operation"])
            {
                if (s == char.Parse(i))
                {
                    return true;
                }
            }
            return false;
        }
        private static bool isQuaotationMark(char s)
        {
            foreach (var i in keywords["Quaotation Mark"])
            {
                if (s == char.Parse(i))
                {
                    return true;
                }
            }
            return false;

        }
        private static bool isBraces(char s)
        {
            foreach (var i in keywords["Braces"])
            {
                if (s == char.Parse(i))
                {
                    return true;
                }
            }
            return false;
        }
        private static bool isAlpha(char ch)
        {
            for (int i = (int)'a'; i <= (int)'z'; i++)
            {
                if (ch == (char)(i)) return true;
            }
            for (int i = (int)'A'; i <= (int)'Z'; i++)
            {
                if (ch == (char)(i)) return true;
            }
            if (ch == '_') return true;
            return false;
        }
        private static bool isDigit(char ch)
        {
            for (int i = 0; i < 10; i++)
            {
                if (ch == (char)(i + 48)) return true;
            }
            return false;

        }
        private static bool isAlphaDigit(char ch)
        {
            if (isAlpha(ch)) return true;
            if (isDigit(ch)) return true;
            return false;

        }
        private static bool isWhiteSpace(char ch)
        {
            if (ch == '\t' || ch == '\n' || ch == ' ' || ch == '\r')
            {
                return true;
            }
            return false;
        }
        public static int Index = 0;
        static private int State = 0;
        static private string Code { get; set; }
        List<Token> primeNumbers = new List<Token>();
        private static Token ReturnKeywords()
        {
            int Temp = Index;
            State = 0;
            string lexeme = "";
            Token t = new Token();

            switch (Code[Index])
            {
                case 'I':
                    lexeme += Code[Index];
                    State = 1; Index++;
                    break;
                case 'E':
                    lexeme += Code[Index];
                    State = 3; Index++;
                    break;
                case 'S':
                    State = 12; Index++;
                    break;
                case 'C':
                    lexeme += Code[Index];
                    State = 17; Index++;
                    break;
                case 'W':
                    lexeme += Code[Index];
                    State = 30; Index++;
                    break;
                case 'T':
                    lexeme += Code[Index];
                    State = 52; Index++;
                    break;
                case 'L':
                    lexeme += Code[Index];
                    State = 8; Index++;
                    break;

            }
            if (State == 0)
            {
                Index = Temp;
                t.Text = "fail";
                return t;
            }
            while (true)
            {
                switch (State)
                {
                    case 1:
                        if (Code[Index] == 'f')
                        {
                            lexeme += Code[Index];
                            State = 2; Index++;

                        }
                        else if (Code[Index] == 'o')
                        {
                            lexeme += Code[Index];
                            State = 9; Index++;
                        }
                        else if (Code[Index] == 't')
                        {
                            lexeme += Code[Index];
                            State = 41; Index++;
                        }
                        else if (Code[Index] == 'n')
                        {
                            lexeme += Code[Index];
                            State = 89; Index++;
                        }
                        else
                        {
                            t.Text = "fail"; Index--;
                            return t;
                        }
                        break;
                    case 2:
                        t.Text = lexeme;
                        t.Type = "Condition";
                        return t;
                        break;
                    case 3:
                        if (Code[Index] == 'l')
                        {
                            lexeme += Code[Index];
                            State = 4;

                        }
                        else
                        {
                            t.Text = "fail";
                            Index = Temp;
                            return t;
                        }
                        break;
                    case 4:
                        if (Code[Index] == 's')
                        {
                            lexeme += Code[Index];
                            State = 5;

                        }
                        else
                        {
                            t.Text = "fail";
                            Index = Temp;
                            return t;
                        }
                        break;
                    case 5:
                        if (Code[Index] == 'e')
                        {
                            lexeme += Code[Index];
                            State = 6; Index++;

                        }
                        else
                        {
                            t.Text = "fail";
                            Index = Temp;
                            return t;
                        }
                        break;

                    case 6:
                        t.Text = lexeme;
                        t.Type = "Condition";
                        return t;
                        break;

                    case 8:
                        if (Code[Index] == 'o')
                        {
                            lexeme += Code[Index];
                            State = 104; Index++;

                        }
                        else
                        {
                            t.Text = "fail";
                            Index = Temp;
                            return t;
                        }
                        break;
                    case 9:
                        if (Index < Code.Length - 1)
                        {
                            if (Code[Index] == 'w' && (Code[Index + 1] == 'f'))
                            {
                                lexeme += Code[Index];
                                Index++;
                                lexeme += Code[Index];
                                State = 26;
                            }
                        }
                        else if (Code[Index] == 'w')
                        {
                            lexeme += Code[Index];
                            State = 10;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;

                    case 10:
                        t.Text = lexeme;
                        t.Type = "Integer";
                        return t;
                        break;
                    
                    case 12:
                        if (Code[Index] == 'I')
                        {
                            lexeme += Code[Index];
                            State = 13; Index++;

                        }
                        else if (Code[Index] == 't')
                        {
                            lexeme += Code[Index];
                            State = 100; Index++;

                        }
                        else
                        {
                            t.Text = "fail";
                            Index = Temp;
                            return t;
                        }
                        break;
                    case 13:
                        if (Code[Index] == 'o')
                        {
                            lexeme += Code[Index];
                            State = 14; Index++;

                        }
                        else
                        {
                            t.Text = "fail";
                            Index = Temp;
                            return t;
                        }
                        break;
                    case 14:
                        if (Index < Code.Length - 1)
                        {
                            if (Code[Index] == 'w' && Code[Index + 1] == 'f')
                            {
                                lexeme += Code[Index];
                                Index++;
                                lexeme += Code[Index];
                                State = 28;
                            }
                        }
                        else if (Code[Index] == 'w')
                        {
                            lexeme += Code[Index];
                            State = 15;
                        }

                        else
                        {
                            t.Text = "fail";
                            Index = Temp;
                            return t;
                        }
                        break;
                    case 15:
                        t.Text = lexeme;
                        t.Type = "SInteger";
                        return t;
                        break;
                    
                    case 17:
                        if (Code[Index] == 'h')
                        {
                            lexeme += Code[Index];
                            State = 18; Index++;

                        }
                        else
                        {
                            t.Text = "fail";
                            Index = Temp;
                            return t;
                        }
                        break;
                    case 18:
                        if (Code[Index] == 'l')
                        {
                            lexeme += Code[Index];
                            State = 19; Index++;

                        }
                        else if(Code[Index] == 'a')
                        {
                            lexeme += Code[Index];
                            State = 22; Index++;

                        }
                        else
                        {
                            t.Text = "fail";
                            Index = Temp;
                            return t;
                        }
                        break;

                    case 104:
                        if (Code[Index] == 'o')
                        {
                            lexeme += Code[Index];
                            State = 40; Index++;

                        }
                        else if (Code[Index] == 'l')
                        {
                            lexeme += Code[Index];
                            State = 61; Index++;

                        }
                        else
                        {
                            t.Text = "fail";
                            Index = Temp;
                            return t;
                        }
                        break;

                    case 19:
                        if (Code[Index] == 'o')
                        {
                            lexeme += Code[Index];
                            State = 20; Index++;

                        }
                        else
                        {
                            t.Text = "fail";
                            Index = Temp;
                            return t;
                        }
                        break;
                    case 20:
                        t.Text = lexeme;
                        t.Type = "Character";
                        return t;
                        break;
                    

                    case 22:
                        if (Code[Index] == 'i')
                        {
                            lexeme += Code[Index];
                            State = 23; Index++;

                        }
                        else
                        {
                            t.Text = "fail";
                            Index = Temp;
                            return t;
                        }
                        break;
                    case 23:
                        if (Code[Index] == 'n')
                        {
                            lexeme += Code[Index];
                            State = 24; Index++;

                        }
                        else
                        {
                            t.Text = "fail";
                            Index = Temp;
                            return t;
                        }
                        break;
                    case 24:
                        t.Text = lexeme;
                        t.Type = "String";
                        return t;
                        break;
                    
                    case 26:
                        t.Text = lexeme;
                        t.Type = "Float";
                        return t;
                        break;
                    
                    case 28:
                        t.Text = lexeme;
                        t.Type = "SFloat";
                        return t;
                        break;

                    case 30:
                        if (Code[Index] == 'o')
                        {
                            lexeme += Code[Index];
                            State = 31; Index++;

                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 31:
                        if (Code[Index] == 'r')
                        {
                            lexeme += Code[Index];
                            State = 32;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 32:
                        if (Code[Index] == 't')
                        {
                            lexeme += Code[Index];
                            State = 33;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 33:
                        if (Code[Index] == 'h')
                        {
                            lexeme += Code[Index];
                            State = 34; Index++;

                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;

                    case 34:
                        if (Code[Index] == 'l')
                        {
                            lexeme += Code[Index];
                            State = 35; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 35:
                        if (Code[Index] == 'e')
                        {
                            lexeme += Code[Index];
                            State = 36;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 36:
                        if (Code[Index] == 's')
                        {
                            lexeme += Code[Index];
                            State = 37;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 37:
                        if (Code[Index] == 's')
                        {
                            lexeme += Code[Index];
                            State = 38;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 38:
                        t.Text = lexeme;
                        t.Type = "Void";
                        return t;
                        break;
                    
                    case 40:
                        if (Code[Index] == 'p')
                        {
                            lexeme += Code[Index];
                            State = 46; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 41:
                        if (Code[Index] == 'e')
                        {
                            lexeme += Code[Index];
                            State = 42;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 42:
                        if (Code[Index] == 'r')
                        {
                            lexeme += Code[Index];
                            State = 43;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 43:
                        if (Code[Index] == 'a')
                        {
                            lexeme += Code[Index];
                            State = 42;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 44:
                        if (Code[Index] == 't')
                        {
                            lexeme += Code[Index];
                            State = 42;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 45:
                        if (Code[Index] == 'e')
                        {
                            lexeme += Code[Index];
                            State = 46; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 46:
                        if (Code[Index] == 'w')
                        {
                            lexeme += Code[Index];
                            State = 47; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 47:
                        if (Code[Index] == 'h')
                        {
                            lexeme += Code[Index];
                            State = 48; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 48:
                        if (Code[Index] == 'e')
                        {
                            lexeme += Code[Index];
                            State = 49; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 49:
                        if (Code[Index] == 'n')
                        {
                            lexeme += Code[Index];
                            State = 50; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 50:
                        t.Text = lexeme;
                        t.Type = "Loop";
                        return t;
                        break;
                    
                    case 52:
                        if (Code[Index] == 'u')
                        {
                            lexeme += Code[Index];
                            State = 53; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 53:
                        if (Code[Index] == 'r')
                        {
                            lexeme += Code[Index];
                            State = 54; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 54:
                        if (Code[Index] == 'n')
                        {
                            lexeme += Code[Index];
                            State = 55;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 55:
                        if (Code[Index] == 'b')
                        {
                            lexeme += Code[Index];
                            State = 56;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 56:
                        if (Code[Index] == 'a')
                        {
                            lexeme += Code[Index];
                            State = 57; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 57:
                        if (Code[Index] == 'c')
                        {
                            lexeme += Code[Index];
                            State = 58; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 58:
                        if (Code[Index] == 'k')
                        {
                            lexeme += Code[Index];
                            State = 59; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 59:
                        t.Text = lexeme;
                        t.Type = "Return";
                        return t;
                        break;
                    
                    case 61:
                        if (Code[Index] == 'i')
                        {
                            lexeme += Code[Index];
                            State = 62;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 62:
                        t.Text = lexeme;
                        t.Type = "Struct";
                        return t;
                        break;

                    case 74:
                        if (Index < Code.Length - 1)
                        {
                            if ((Code[Index] == '>' || Code[Index]=='<') && Code[Index + 1] == '=')
                            {
                                lexeme += Code[Index];
                                Index++;
                                lexeme += Code[Index];
                                State = 75;
                            }
                        }
                        else if (Code[Index] == '>'||Code[Index] == '<')
                        {
                            lexeme += Code[Index];
                            State = 76;
                        }

                        else
                        {
                            t.Text = "fail";
                            Index = Temp;
                            return t;
                        }
                        break;

                    case 75:
                        t.Text = lexeme;
                        t.Type = "relational operator";
                        break;
                    case 90:
                        if (Code[Index] == 'l')
                        {
                            lexeme += Code[Index];
                            State = 91;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 91:
                        if (Code[Index] == 'u')
                        {
                            lexeme += Code[Index];
                            State = 92;
                        }
                        break;
                    case 92:
                        if (Code[Index] == 'd')
                        {
                            lexeme += Code[Index];
                            State = 93;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;

                        case 93:
                        if (Code[Index] == 'e')
                        {
                            lexeme += Code[Index];
                            State = 95; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            t.Text = "fail";
                            return t;
                        }
                        break;
                    case 94:
                        t.Text = lexeme;
                        t.Type = "Inclusion";
                        return t;
                        break;
                    
   
                   
                }
            }
        }
        private static Token ReturnSymoble()
        {
            int Temp = Index;
            State = 0;
            Token T = new Token();
            string lexeme = "";
            while (true)
            {
                switch (State)
                {
                    case 0:
                        if (Code[Index] == '>')
                        {
                            lexeme += Code[Index];
                            State = 74; Index++;
                        }
                        else if (Code[Index] == '=' || Code[Index] == '!')
                        {
                            lexeme += Code[Index];
                            State = 73; Index++;
                        }
                        
                        else if (Code[Index] == '~')
                        {
                            lexeme += Code[Index];
                            State = 71; Index++;
                        }
                        else if (Code[Index] == '&')
                        {
                            lexeme += Code[Index];
                            State = 69; Index++;
                        }
                        else if (Code[Index] == '|')
                        {
                            lexeme += Code[Index];
                            State = 70; Index++;
                        }
                        
                        else if (isArithmeticOperation(Code[Index]))
                        {
                            lexeme += Code[Index];
                            State = 68;
                        }
                        else if (isBraces(Code[Index]))
                        {
                            lexeme += Code[Index];
                            State = 83;
                        }
                        else if (isQuaotationMark(Code[Index]))
                        {
                            lexeme += Code[Index];
                            State = 87;
                        }
                        
                        else
                        {
                            Index = Temp;
                            T.Text = "fail";
                            return T;
                        }
                        break;

                    case 69:
                        if (Index < Code.Length)
                        {
                            if (Code[Index] == '&')
                            {
                                lexeme += Code[Index];
                                State = 71;
                            }
                            else
                            {
                                Index--;
                                T.Text = lexeme;
                                T.Type = "Error";
                                return T;
                            }
                        }
                        else
                        {
                            Index--;
                            T.Text = lexeme;
                            T.Type = "Error";
                            return T;
                        }
                        break;
                    case 71:
                        T.Text = lexeme;
                        T.Type = "Logic Operator";
                        return T;
                        break;
                    case 70:
                        if (Index < Code.Length)
                        {
                            if (Code[Index] == '|')
                            {
                                lexeme += Code[Index];
                                State = 71;
                            }
                            else
                            {
                                Index--;
                                T.Text = lexeme;
                                T.Type = "Error";
                                return T;
                            }
                        }
                        else
                        {
                            Index--;
                            T.Text = lexeme;
                            T.Type = "Error";
                            return T;
                        }
                        break;
          
                    case 79:
                        T.Text = lexeme;
                        T.Type = "Access Operator";
                        return T;
                        break;
                    case 68:
                        T.Text = lexeme;
                        T.Type = "Arithmetic Operator";
                        return T;
                        break;
                    case 83:
                        T.Text = lexeme;
                        T.Type = "Braces";
                        return T;
                        break;
                    case 87:
                        T.Text = lexeme;
                        T.Type = "Quotation Mark";
                        return T;
                        break;
                    
                }
            }

            T.Text = "fail";
            return T;
        }
        private static Token ReturnIdentifier()
        {
            int Temp = Index;
            State = 0;
            Token T = new Token();
            string lexeme = "";
            while (true)
            {
                switch (State)
                {
                    case 0:
                        if (isAlpha(Code[Index]))
                        {
                            lexeme += Code[Index];
                            State = 96; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            T.Text = "fail";
                            return T;
                        }
                        break;
                    case 96:
                        if (Index <= Code.Length - 1)
                        {
                            if (isAlphaDigit(Code[Index]))
                            {
                                lexeme += Code[Index];
                                State = 97; Index++;
                            }
                            else
                            {
                                Index--;
                                T.Text = lexeme;
                                T.Type = "Identifier";
                                return T;
                            }
                        }
                        else
                        {
                            Index--;
                            T.Text = lexeme;
                            T.Type = "Identifier";
                            return T;
                        }
                        break;
                    case 97:
                        if (Index <= Code.Length - 1)
                        {
                            if (isAlphaDigit(Code[Index]))
                            {
                                lexeme += Code[Index];
                                State = 97; Index++;
                            }
                            else
                            {
                                Index--;
                                T.Text = lexeme;
                                T.Type = "Identifier";
                                return T;
                            }
                        }
                        else
                        {
                            Index--;
                            T.Text = lexeme;
                            T.Type = "Identifier";
                            return T;
                        }
                        break;



                }
            }
            Index = Temp;
            T.Text = "fail";
            return T;
        }
        private static Token ReturnComment()
        {
            int Temp = Index;
            State = 0;
            Token T = new Token();
            string lexeme = "";
            while (true)
            {
                switch (State)
                {
                    case 0:
                        if (Code[Index] == '/')
                        {
                            lexeme += Code[Index];
                            State = 142; Index++;
                        }
                        else if (Code[Index] == '$')
                        {
                            lexeme += Code[Index];
                            State = 147; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            T.Text = "fail";
                            return T;
                        }
                        break;
                    case 142:
                        if (Index <= Code.Length - 1)
                        {
                            if (Code[Index] == '$')
                            {
                                lexeme += Code[Index];
                                State = 143; Index++;
                            }
                            else
                            {
                                Index = Temp;
                                T.Text = "fail";
                                return T;
                            }
                        }
                        else
                        {
                            Index = Temp;
                            T.Text = "fail";
                            return T;
                        }
                        break;
                    case 143:
                        if (Index <= Code.Length - 1)
                        {
                            if (Code[Index] == '$')
                            {
                                lexeme += Code[Index];
                                State = 145; Index++;
                            }
                            else if (Code[Index] != '$' || isWhiteSpace(Code[Index]))
                            {
                                lexeme += Code[Index];
                                State = 144; Index++;
                            }
                            else
                            {
                                Index = Temp;
                                T.Text = "fail";
                                return T;
                            }
                        }
                        else
                        {
                            Index = Temp;
                            T.Text = "fail";
                            return T;
                        }
                        break;
                    case 144:
                        if (Index <= Code.Length - 1)
                        {
                            if (Code[Index] != '$' || isWhiteSpace(Code[Index]))
                            {
                                lexeme += Code[Index];
                                State = 144; Index++;
                            }
                            else if (Code[Index] == '$')
                            {
                                lexeme += Code[Index];
                                State = 145; Index++;
                            }
                            else
                            {
                                Index = Temp;
                                T.Text = "fail";
                                return T;
                            }
                        }
                        else
                        {
                            T.Text = lexeme;
                            T.Type = "Mutiple Comment";
                            return T;
                        }
                        break;
                    case 145:
                        if (Index <= Code.Length - 1)
                        {
                            if (Code[Index] == '/')
                            {
                                lexeme += Code[Index];
                                State = 146;
                            }
                            else
                            {
                                Index = Temp;
                                T.Text = "fail";
                                return T;
                            }
                        }
                        else
                        {
                            Index = Temp;
                            T.Text = "fail";
                            return T;
                        }
                        break;
                    case 146:
                        T.Text = lexeme;
                        T.Type = "Mutiple Comment";
                        return T;
                        break;
                    //case 142 is completed
                    case 147:
                        if (Code[Index] == '$')
                        {
                            lexeme += Code[Index];
                            State = 148; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            T.Text = "fail";
                            return T;
                        }
                        break;

                    case 148:
                        if (isAlphaDigit(Code[Index]) || Code[Index] == ' ' || Code[Index] == '\t')
                        {
                            lexeme += Code[Index];
                            State = 149; Index++;
                        }
                        else
                        {
                            Index--;
                            T.Text = lexeme;
                            T.Type = "Single Comment";
                            return T;
                        }
                        break;
                    case 149:
                        if (Index <= Code.Length - 1)
                        {
                            if (isAlphaDigit(Code[Index]) || Code[Index] == ' ' || Code[Index] == '\t')
                            {
                                lexeme += Code[Index];
                                State = 149; Index++;
                            }
                            else
                            {
                                Index--;
                                T.Text = lexeme;
                                T.Type = "Single Comment";
                                return T;

                            }
                        }
                        else
                        {
                            T.Text = lexeme;
                            T.Type = "Single Comment";
                            return T;
                        }
                        break;


                }
            }

            T.Text = "fail";
            return T;
        }
        private static Token ReturnConstant()
        {
            int Temp = Index;
            int flag = 0;
            State = 0;
            Token T = new Token();
            string lexeme = "";
            while (true)
            {
                switch (State)
                {

                    case 0:
                        if (isDigit(Code[Index]))
                        {

                            lexeme += Code[Index];
                            State = 145; Index++;
                        }
                        else
                        {
                            Index = Temp;
                            T.Text = "fail";
                            return T;

                        }
                        break;
                    case 145:
                        if (Index <= Code.Length - 1)
                        {
                            if (isDigit(Code[Index]))
                            {
                                lexeme += Code[Index];
                                State = 145; Index++;
                            }
                            else if (isAlphaDigit(Code[Index]))
                            {
                                if ((Index + 1) <= (Code.Length - 1) && isAlphaDigit(Code[Index + 1]))
                                {
                                    flag = 1;
                                    lexeme += Code[Index];
                                    State = 145; Index++;
                                }
                                else
                                {
                                    lexeme += Code[Index];
                                    T.Text = lexeme;
                                    T.Type = "Error";
                                    return T;
                                }
                            }
                            else
                            {
                                Index--;
                                T.Text = lexeme;
                                T.Type = "Constant";
                                return T;
                            }
                        }
                        else if (flag == 1)
                        {
                            Index--;
                            T.Text = lexeme;
                            T.Type = "Error";
                            return T;
                        }
                        else
                        {

                            Index--;
                            T.Text = lexeme;
                            T.Type = "Constant";
                            return T;
                        }
                        break;

                }
            }
            Index = Temp;
            T.Text = "fail";
            return T;
        }
        private static List<Token> Scanner()
        {
            Index = 0;
            int i = 0;
            Console.WriteLine(Code);
            Token a = new Token();
            List<Token> tokens = new List<Token>();
            while (Index < Code.Length)
            {
                if (isWhiteSpace(Code[Index]))
                {
                    if (Code[Index] == '\n')
                    {

                        Line++;
                    }
                    Index++;
                    i++;
                }
                else
                {
                    a = ReturnComment();
                    if (a.Text != "fail")
                    {
                        a.LineNum = Line;

                        tokens.Add(a); Index++;
                        continue;

                    }

                    a = ReturnKeywords();
                    if (a.Text != "fail")
                    {
                        a.LineNum = Line;
                        tokens.Add(a); Index++;
                        continue;

                    }
                    a = ReturnIdentifier();
                    if (a.Text != "fail")
                    {
                        a.LineNum = Line;
                        tokens.Add(a); Index++;
                        continue;
                    }
                    a = ReturnSymoble();
                    if (a.Text != "fail")
                    {
                        a.LineNum = Line;
                        tokens.Add(a); Index++;
                        continue;

                    }
                    else if (a.Type == "Error")
                    {
                        a.LineNum = Line;
                        tokens.Add(a); Index++;
                        continue;

                    }
                    a = ReturnConstant();
                    if (a.Text != "fail")
                    {
                        a.LineNum = Line;
                        tokens.Add(a); Index++;
                        continue;

                    }
                    else if (a.Type == "Error")
                    {
                        a.LineNum = Line;
                        tokens.Add(a); Index++;
                        continue;

                    }
                    Index++;
                    i++;
                }
            }
            return tokens;
        }
        public static List<string> DisplayTokens(string code)
        {
            List<Token> y = new List<Token>();
            List<string> Tok = new List<string>();
            Code = code;
            y = Scanner();
            var x = y;
            foreach (var i in y)
            {
                if (i.Type == "Error")
                {
                    NumOfError++;
                    Tok.Add("Line  : " + i.LineNum + "  " + " Error in Token Text  :  " + i.Text);

                }
                else
                {
                    Tok.Add("Line  : " + i.LineNum + "  " + " Token Text:  " + i.Text + " Token Type  :  " + i.Type);

                }
            }
            if (Tok.Count != 0)
            {
                Tok.Add("Total NO of errors  :" + NumOfError);
                return Tok;
            }
            else
            {

                return Tok;
            }

        }
        public static string getCodeFromFile(string txt)
        {
            string text;
            if (System.IO.File.Exists(@txt))
            {
                text = System.IO.File.ReadAllText(@txt);
            }
            else
                text = txt;

            return text;
        }
    }
}
