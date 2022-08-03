using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace task3
{
    class PolandRecord
    {
        string formula;
        string formulaPoland;
        SortedSet<char> operations = new SortedSet<char>();
        List<string> formulaList;

        public PolandRecord(string formula = "")
        {
            this.formula = formula;
            this.FormulaPoland = "";
            this.formulaList = new List<string>();
            //this.operations.Add('+');
            //this.operations.Add('-');
            //this.operations.Add('*');
            //this.operations.Add('/');
            operations = new SortedSet<char>() { '+', '-', '*', '/' };
        }

        public string FormulaPoland { get => formulaPoland; set => formulaPoland = value; }

        public int Prioritet(char operation)
        {
            int res = -1;
            switch (operation)
            {
                case '+':
                    {
                        res = 0;
                    }
                    break;
                case '-':
                    {
                        res = 0;
                    }
                    break;
                case '*':
                    {
                        res = 1;
                    }
                    break;
                case '/':
                    {
                        res = 1;
                    }
                    break;
                default:
                    {
                        res = -1;
                    }
                    break;
            }
            return res;
        }

        public void CreatePoland()
        {
            List<char> stack = new List<char>();
            formulaPoland = "";
            formula = formula.Replace(" ", "");
            for(int i = 0; i < formula.Length; i++)
            {
                if (char.IsDigit(formula[i]) || formula[i] == '.' /*|| IsSin(formula, i)*/)
                {
                    formulaPoland += formula[i];
                }
                else
                {
                    formulaPoland += " ";
                }

                if(formula[i] == '(')
                {
                    stack.Insert(0, formula[i]);
                }

                if(formula[i] == ')')
                {
                    while (stack.Count != 0 && stack[0] != '(')
                    {
                        formulaPoland += stack[0] + " ";
                        stack.RemoveAt(0);
                    }

                    if(stack.Count != 0)
                    {
                        stack.RemoveAt(0);
                    }
                    else
                    {
                        throw new PolandRecordException("formula not correct");
                    }
                }

                if (operations.Contains(formula[i]))
                {
                    while(stack.Count != 0 && Prioritet(stack[0]) > Prioritet(formula[i]))
                    {
                        formulaPoland += stack[0] + " ";
                        stack.RemoveAt(0);
                    }
                    stack.Insert(0, formula[i]);
                }
            }
            while (stack.Count != 0)
            {
                if (operations.Contains(stack[0]))
                {
                    formulaPoland += stack[0];
                    stack.RemoveAt(0);
                }
                else
                {
                    throw new PolandRecordException("not balance ()");
                }
            }

            formulaPoland = formulaPoland.Replace("  ", " ");
        }

        public void CreatePolandComplete()
        {
            Stack<string> stack = new Stack<string>();
            string diggit = "";

            for(int i = 0; i< formula.Length; i++)
            {
                if (char.IsDigit(formula[i]) || formula[i] == ',' || formula[i] == '.')
                {
                    diggit += formula[i];
                }

                //if(formula)
            }
        }

        public List<string> CreateLexems()
        {
            Stack<int> stack = new Stack<int>();
            char[] chars = { '(', ')'};
            List<string> bracketsLexems = new List<string>();

            for(int i = 0; i<formula.Length; i++)
            {
                if(formula[i] == '(')
                {
                    stack.Push(i);
                }

                if(formula[i] == ')')
                {
                    if(stack.Count == 1)
                    {
                        int indexStart = stack.Pop();
                        int indexEnd = i;
                        Console.WriteLine($"{indexStart} - {indexEnd}");
                        bracketsLexems.Add(formula.Substring(indexStart, indexEnd - indexStart+1));
                    }
                    else
                    {
                        int indexStart = stack.Pop();
                    }
                }
            }

            Console.WriteLine(formula);
            foreach(string bracket in bracketsLexems)
            {
                Console.WriteLine(bracket);
            }
            Console.WriteLine();




            string[] mas = formula.Split(operations.ToArray());
            return new List<string>();
        }

        public List<string> CreateLexems2()
        {
            SortedSet<char> limited = new SortedSet<char>() { '+', '-', '*', '/' };
            limited.Add('(');
            limited.Add(')');

            char[] chars = { '(', ')' };
            

            string[] mas = formula.Split(limited.ToArray());
            List<string> res = new List<string>();
            foreach(string el in mas)
            {
                if (!(el == null || el == ""))
                {
                    res.Add(el);
                }
            }
            return res;
        }

        public bool IsMyFunc(string lexema, Dictionary<string, Func<double, double>> functions)
        {
            if (lexema[lexema.Length - 1] != ')')
            {
                return false;
            }

            int index = lexema.IndexOf('(');
            if (index == -1)
            {
                return false;
            }

            string name = lexema.Substring(0, index - 1);
            if (functions.ContainsKey(name))
            {
                return true;
            }
            return false;
        }
    }
}
