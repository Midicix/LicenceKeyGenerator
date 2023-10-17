namespace randomActivationKey
{
    internal class Program
    {
        static void choiceLicence()
        {
            int choice = 0;
            int repeat;
            int part = 5;
            bool convert = false;
            bool convert2 = false;
            bool convert3 = false;

            while (!convert)
            {
                Console.Clear();
                Console.Write("Voulez-vous une licence avec des lettres (1), des chiffres (2) ou bien les deux ? (3) : ");
                convert = int.TryParse(Console.ReadLine(), out choice);
                if (convert)
                {
                    if (choice > 3 || choice < 1)
                    {
                        convert = false;
                    }
                }
            }

            while (!convert2)
            {
                Console.Clear();
                Console.WriteLine("Voulez-vous une licence avec des lettres (1), des chiffres (2) ou bien les deux ? (3) : {0}", choice);
                Console.Write("De combien de fois voulez-vous que la période de caractères entre tirets soient composés ? 2 fois minimum (par défaut = 5) : ");
                convert2 = int.TryParse(Console.ReadLine(), out part);
                if (!convert2 || part < 2)
                {
                    part = 5;
                    convert2 = true;
                }
            }

            do
            {
                Console.Clear();
                Console.WriteLine("Voulez-vous une licence avec des lettres (1), des chiffres (2) ou bien les deux ? (3) : {0}", choice);
                Console.WriteLine("De combien de fois voulez-vous que la période de caractères entre tirets soient composés ? 2 fois minimum (par défaut = 5) : {0}", part);
                Console.Write("Combien de fois voulez-vous que la période de {0} caractères se répète ? 2 fois minimum (par défaut = 6) : ", part);
                convert3 = int.TryParse(Console.ReadLine(), out repeat);

                if (!convert3 || repeat < 2)
                {
                    repeat = 6;
                    convert3 = true;
                }
            }
            while (!convert3);


            Console.Clear();
            Console.WriteLine("Voulez-vous une licence avec des lettres (1), des chiffres (2) ou bien les deux ? (3) : {0}", choice);
            Console.WriteLine("De combien de fois voulez-vous que la période de caractères entre tirets soient composés ? 2 fois minimum (par défaut = 5) : {0}", part);
            Console.WriteLine("Combien de fois voulez-vous que la période de {0} caractères se répète ? 2 fois minimum (par défaut = 6) : {1}", part, repeat);

            Console.WriteLine("\n\n Here's your key : {0}", CreateLicenceKey(choice, repeat, part));
        }
        static string CreateLicenceKey(int cara, int nbpart = 6, int nbcharbetsub = 5)
        {
            Random random = new Random();
            string code = "";

            if (cara == 1)
            {
                for (int i = 1; i < nbpart * (nbcharbetsub + 1); i++)
                {
                    if (i % (nbcharbetsub + 1) == 0)
                    {
                        code += "-";
                    }
                    else
                    {
                        code += Convert.ToChar(random.Next(Convert.ToInt32('A'), Convert.ToInt32('A') + Convert.ToInt32('Z') - Convert.ToInt32('A') + 1));
                    }
                }
            }
            if (cara == 2)
            {
                for (int i = 1; i < nbpart * (nbcharbetsub + 1); i++)
                {
                    if (i % (nbcharbetsub + 1) == 0)
                    {
                        code += "-";
                    }
                    else
                    {
                        code += Convert.ToString(random.Next(0, 10));
                    }
                }
            }
            if (cara == 3)
            {
                for (int i = 1; i < nbpart * (nbcharbetsub + 1); i++)
                {
                    if (i % (nbcharbetsub + 1) == 0)
                    {
                        code += "-";
                    }
                    else
                    {
                        int caractere = random.Next(0, 2);
                        if (caractere == 0)
                        {
                            code += Convert.ToChar(random.Next(Convert.ToInt32('A'), Convert.ToInt32('A') + Convert.ToInt32('Z') - Convert.ToInt32('A') + 1));

                        }
                        else
                        {
                            code += Convert.ToString(random.Next(0, 10));
                        }
                    }
                }
            }
            return code;
        }
        static void Main(string[] args)
        {
            choiceLicence();
        }
    }
}