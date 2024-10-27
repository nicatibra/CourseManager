namespace CourseManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string choice;
            do
            {
                Console.WriteLine("Secim edin: ");
                Console.WriteLine("1. Yeni qrup yaratmaq.\n2. Qruplarin siyahisini gostermek.\n3. Qrup uzerinde duzelis etmek.\n4. Qrupdaki telebelerin siyahisini gostermek.\n5. Butun telebelerin sitahisini gostermek.\n6. Telebe yarat.\n\n0. Proqramdan cixmaq.");

                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        Services.CreateGroup();

                        break;

                    case "2":
                        Console.Clear();
                        Services.ShowAllGroups();
                        break;

                    case "3":
                        Console.Clear();
                        Services.EditGroupInfo();
                        break;

                    case "4":
                        Console.Clear();
                        Services.ShowStudentsOfgroup();
                        break;

                    case "5":
                        Console.Clear();
                        Services.ShowAllStudents();
                        break;

                    case "6":
                        Console.Clear();
                        Services.CreateStudent();
                        break;

                    case "0":
                        Console.WriteLine("Proqramdan cixildi.");
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Duzgun secim edin.\n");
                        break;
                }

            } while (choice != "0");
        }
    }
}
