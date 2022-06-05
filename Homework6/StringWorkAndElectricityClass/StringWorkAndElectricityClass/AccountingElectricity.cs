using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringWorkAndElectricityClass
{
    internal class AccountingElectricity
    {

        private List<KeyValuePair<string, int>> accounts;
        private Information[,] electricity;
        private int countApartment;

        public int CountApartment
        {
            get
            {
                if(!int.TryParse(countApartment.ToString(), out countApartment))
                {
                    throw new FormatException("inccorect count of apartment, you need input degets");
                }
                if (countApartment < 0)
                {
                    throw new IndexOutOfRangeException("inccorect count of apartmnet");
                }
                return countApartment;
            }
        }

        //private Dictionary<List<KeyValuePair<int, string>>, List<Information>> informations;

        public AccountingElectricity()
        {
            this.accounts = new List<KeyValuePair<string, int>>();
            this.electricity = new Information[0,0];
            this.countApartment = 0;
        }

        public AccountingElectricity(StreamReader sr)
        {
            this.accounts = new List<KeyValuePair<string, int>>();
            ReadFromFile(sr);
        }

        public AccountingElectricity(List<KeyValuePair<string, int>> accounts, Information[,] electricity)
        {
            this.accounts = accounts;
            this.electricity = electricity;
            this.countApartment = accounts.Count;
        }

        public void ReadFromFile(StreamReader sr) // зчитуєм з файла
        {
            //List<Information> lst = new List<Information>();
            string line = sr.ReadLine();
            countApartment = int.Parse(line.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0]);
            int quarter = int.Parse(line.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0]);
            electricity = new Information[countApartment, 3];

            try
            {
                //Console.WriteLine(lst);
                for (int i = 0; i < countApartment; i++)
                {
                    line = sr.ReadLine();
                    AccountCheck.CheckLine(line);
                    int numberApartment = int.Parse(line.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0]);
                    string surname = line.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1];
                    accounts.Add(new KeyValuePair<string, int>(surname, numberApartment));

                    for (int j = 0; j < 3; j++)
                    {
                        double inputIndecator = double.Parse(line.Split(' ', StringSplitOptions.RemoveEmptyEntries)[2 + j * 3]);
                        double outputIndecator = double.Parse(line.Split(' ', StringSplitOptions.RemoveEmptyEntries)[3 + j * 3]);
                        string date = line.Split(' ', StringSplitOptions.RemoveEmptyEntries)[4 + j * 3];
                        Information information = new Information(inputIndecator, outputIndecator, date);
                        electricity[i, j] = information;
                        //lst.Add(information);
                    }
                    //informations.Add(accounts, lst);
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new IndexOutOfRangeException("inccorect index count apartment");
            }
        }

        public override string? ToString()
        {
            string res = null;
            for(int i = 0; i< accounts.Count; i++)
            {
                res += String.Format("Surname: {0,10}  || apartment: {1,10}",accounts[i].Key, accounts[i].Value);
                for(int j = 0; j < 3; j++)
                {
                    res += String.Format("{0,10} \t\t", electricity[i, j]);
                    //res += $"\t{electricity[i, j]} \t";
                }
                res += "\n";
            }
            return res;
        }

        public void WriteToFile(string fileName)
        {
            using(StreamWriter sw = new StreamWriter(fileName))
            {
                sw.WriteLine(new AccountingElectricity(accounts, electricity));
            }
        }

        public string CheckOneApartment(int numberApartmnet)
        {
            string res = "";
            List<int> indexApartment = new List<int>();
            for(int i = 0; i < CountApartment; i++)
            {
                if(accounts[i].Value == numberApartmnet)
                {
                    indexApartment.Add(i);
                }
            }

            for(int i = 0; i<indexApartment.Count; i++)
            {
                res += String.Format("Surname: {0,10}  || apartment: {1,10}", accounts[indexApartment[i]].Key, accounts[indexApartment[i]].Value);
                for (int j = 0; j < 3; j++)
                {
                    res += String.Format("{0,10} \t\t", electricity[indexApartment[i], j]);
                    //res += $"\t{electricity[i, j]} \t";
                }
                res += "\n";
            }
            return res;
        }

        public double Arrears(int numberRow)
        {
            double counter = 0;
            for (int j = 0; j < 3; j++)
            {
                counter += electricity[numberRow, j].OutputIndecator - electricity[numberRow, j].InputIndecator;
            }

            return counter;
        }

        public List<int> IndexTheMostArrears()
        {
            double count = 0;
            
            List<int> res = new List<int>();
            List<double> lst = new List<double>();
            for(int i = 0; i < countApartment; i++)
            {
                if(count < Arrears(i))
                {
                    count = Arrears(i);
                }
                lst.Add(Arrears(i));
            }
            double max = lst.Max(el => el = count);
            for(int i = 0; i < lst.Count; i++)
            {
                if(max == lst[i])
                {
                    res.Add(i);
                }
            }
            return res;
        }

        public string SurnameArrears()
        {
            string res = "";
            List<string> lst = new List<string>();
            for(int i = 0; i < IndexTheMostArrears().Count; i++)
            {

                lst.Add(accounts[IndexTheMostArrears()[i]].Key);
            }
            //foreach (int el in IndexTheMostArrears())
            //{
            //    lst.Add(accounts[el].Key);
            //}
            foreach(string el in lst)
            {
                res += $"surname {el}.  ||\t";
            }
            return res;
        }

        public List<int> IndexNotConsumeElecticiry()
        {
            double count = 0;

            List<int> res = new List<int>();
            List<double> lst = new List<double>();
            for (int i = 0; i < countApartment; i++)
            {
                lst.Add(Arrears(i));
            }
            for (int i = 0; i < lst.Count; i++)
            {
                if (lst[i] == 0)
                {
                    res.Add(i);
                }
            }
            return res;
        }

        public string SurnameWhoIsNotConsumeElectricity()
        {
            string res = "";
            List<string> lst = new List<string>();
            foreach (int el in IndexNotConsumeElecticiry())
            {
                lst.Add(accounts[el].Key);
            }
            foreach (string el in lst)
            {
                res += $"surname {el}.  ||\t";
            }
            return res;
        }

        public List<double> CostElectricityConsume()
        {
            List<double> res = new List<double>();
            double count = 0;
            for(int i = 0; i < countApartment; i++)
            {
                res.Add(Arrears(i) * ElectricityConst.electricityConst);
            }

            return res;
        }

        public void AmountOfCost()
        {
            List<double> lst = CostElectricityConsume();
            string res = null;

            for(int i = 0; i < countApartment; i++)
            {
                res += String.Format("Surname: {0,10}  || apartment: {1,10} || amount cost = {2,-10} \n", accounts[i].Key, accounts[i].Value, lst[i]);
            }
            Console.WriteLine(res);

        }

        public TimeSpan DifferenceBetweenDate(int numberApartment)
        {
            TimeSpan res = DateTime.Today.Subtract(electricity[numberApartment, 2].Date);
            return res;
        }

        public void ShowDifferenceDate()
        {
            string res = null;
            for (int i = 0; i < countApartment; i++)
            {
                res += String.Format("Surname: {0,10}  || apartment: {1,10} || diffrence between today and date in the file = {2,-10} \n", accounts[i].Key, accounts[i].Value, DifferenceBetweenDate(i));
            }
            Console.WriteLine(res);
        }
    }
}
