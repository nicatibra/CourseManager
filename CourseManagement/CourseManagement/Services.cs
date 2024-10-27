using CourseManagement.Models;

namespace CourseManagement
{
    internal class Services
    {
        static List<Group> groups = new List<Group>();

        public static bool CheckForDuplicateGroup(string groupNo)
        {
            foreach (Group group in groups)
            {
                if (group.GroupNo == groupNo)
                {
                    return true;
                }
            }
            return false;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------

        public static void CreateGroup()
        {
            string groupNo;
            string fullGroupNo = null;
            string groupCategory = null;

            do
            {
                do
                {
                    Console.WriteLine("Qrupun nomresini daxil edin (0-dan boyuk olmalidir, ana menyuya qayitmaq ucun 0 yazin): ");
                    groupNo = Console.ReadLine();
                    Console.Clear();

                    if (groupNo == "0") return;
                } while (string.IsNullOrWhiteSpace(groupNo) || !int.TryParse(groupNo, out int number) || number <= 0);

                Console.Clear();

                int categoryChoice;
                bool validCategory = false;
                do
                {

                    Console.WriteLine("Qrupun kateqoriyasini secin (ana menyuya qayitmaq ucun 0 yazin): ");
                    Console.WriteLine("1. Programming \n2. Design \n3. System Administration");
                    string categoryInput = Console.ReadLine();

                    Console.Clear();

                    if (categoryInput == "0") return;

                    if (int.TryParse(categoryInput, out categoryChoice))
                    {
                        switch (categoryChoice)
                        {
                            case (int)Categories.Programming:
                                fullGroupNo = "P" + groupNo;
                                groupCategory = "Programming";
                                validCategory = true;
                                break;
                            case (int)Categories.Design:
                                fullGroupNo = "D" + groupNo;
                                groupCategory = "Design";
                                validCategory = true;
                                break;
                            case (int)Categories.SystemAdministration:
                                fullGroupNo = "S" + groupNo;
                                groupCategory = "System Administration";
                                validCategory = true;
                                break;
                            default:
                                Console.Clear();
                                Console.WriteLine("Var olan kateqoriya secilmedi.\n");
                                break;
                        }
                    }
                } while (!validCategory);

                if (CheckForDuplicateGroup(fullGroupNo))
                {
                    Console.Clear();
                    Console.WriteLine("Bele adli qrup artiq movcuddur. Yeni bir qrup nomresi ve ya kateqoriya daxil edin.\n");
                }

            } while (CheckForDuplicateGroup(fullGroupNo));

            Console.Clear();

            string groupOnline = null;
            while (groupOnline == null)
            {
                Console.WriteLine("Qrupunuz online-dir? (ana menyuya qayitmaq ucun 0 yazin)");
                Console.WriteLine("1. Beli \n2. Xeyr");
                string onlineInput = Console.ReadLine();

                Console.Clear();

                if (onlineInput == "0") return;

                if (int.TryParse(onlineInput, out int onlineChoice))
                {
                    switch (onlineChoice)
                    {
                        case 1:
                            groupOnline = "Online";
                            break;
                        case 2:
                            groupOnline = "Offline";
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Duzgun secim edin.\n");
                            break;
                    }
                }
            }
            Console.Clear();

            Group group = new Group(fullGroupNo, groupCategory, groupOnline);
            Console.WriteLine("Yeni qrup ugurla yaradildi!\n");
            groups.Add(group);
        }



        //--------------------------------------------------------------------------------------------------------------------------------------------------



        public static void ShowAllGroups()
        {
            if (!groups.Any())
            {
                Console.WriteLine("Her hansisa bir qrup movcud deyil. Yeni bir qrup yaradin.\n");
                CreateGroup();
                return;
            }
            else
            {
                foreach (Group group in groups)
                {
                    Console.WriteLine($"{group.ToString()}, Student Count: {group.students.Count}\n");
                }
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------

        public static void EditGroupInfo()
        {
            if (!groups.Any())
            {
                Console.WriteLine("Her hansisa bir qrup movcud deyil. Yeni bir qrup yaradin. \n");
                CreateGroup();
                return;
            }

            string inputedGroup;
            bool groupFound;

            do
            {
                Console.Clear();
                Console.WriteLine("Hansi qrup deyismek isteyirsiz? (Ana menyuya qayitmaq ucun 0 daxil edin)");
                foreach (Group group in groups)
                {
                    Console.WriteLine(group.GroupNo);
                }

                inputedGroup = Console.ReadLine();

                if (inputedGroup == "0")
                {
                    Console.Clear();
                    return;
                }

                groupFound = false;

                foreach (Group group in groups)
                {
                    if (inputedGroup.ToUpper() == group.GroupNo.ToUpper())
                    {
                        groupFound = true;

                        string newNo;

                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Yeni qrup nomresini daxil edin (0-dan boyuk olmalidir):");

                            newNo = Console.ReadLine().Trim();


                        } while (string.IsNullOrWhiteSpace(newNo) || !int.TryParse(newNo, out int number) || number <= 0);

                        if (group.GroupNo.Substring(0, 1) == "P")
                        {
                            group.GroupNo = "P" + newNo;
                        }
                        else if (group.GroupNo.Substring(0, 1) == "D")
                        {
                            group.GroupNo = "D" + newNo;
                        }
                        else if (group.GroupNo.Substring(0, 1) == "S")
                        {
                            group.GroupNo = "S" + newNo;
                        }

                        Console.Clear();
                        Console.WriteLine("Qrup nomresi ugurla deyisdirildi!\n");
                        break;
                    }
                }

                if (!groupFound)
                {
                    Console.WriteLine("Qrup adini duzgun daxil edin.\n");
                }

            } while (!groupFound);
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------------


        public static void ShowStudentsOfgroup()
        {
            if (!groups.Any())
            {
                Console.WriteLine("Her hansisa bir qrup movcud deyil. Yeni bir qrup yaradin. \n");
                CreateGroup();
                return;
            }

            Console.WriteLine("Hansi qrupa baxmaq isteyirsiz?");
            foreach (Group group in groups)
            {
                Console.WriteLine(group.GroupNo);
            }

            string thisgroup = Console.ReadLine();

            Console.Clear();
            foreach (Group group in groups)
            {
                if (group.GroupNo != thisgroup)
                {
                    Console.WriteLine("Bele bir qrup movcud deyil, yeniden cehd edin.\n");
                }
                else if (!group.students.Any())
                {
                    Console.WriteLine("Bu qrupda telebeler yoxdur.\n");

                }
                else if (group.GroupNo.ToUpper() == thisgroup.ToUpper())
                {
                    foreach (Student student in group.students)
                    {
                        Console.WriteLine($"{student.Name} {student.Surname}");
                    }
                    Console.WriteLine();
                }
            }
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------------


        public static void ShowAllStudents()
        {

            if (!groups.Any())
            {
                Console.WriteLine("Qruplar yaradilmayib. Ilk once qrup yaradin: \n");
                CreateGroup();
                return;
            }

            foreach (Group group in groups)
            {
                if (group.students.Any())
                {
                    Console.WriteLine($"From Group {group.GroupNo}: ");
                    foreach (Student student in group.students)
                    {
                        Console.WriteLine($"{student.ToString()}");
                    }
                    Console.WriteLine();

                }
                else
                {
                    Console.WriteLine("Hec bir qrupda telebe yoxdur.\n");

                }
            }
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------------

        public static void CreateStudent()
        {
            if (!groups.Any())
            {
                Console.WriteLine("Her hansisa bir qrup movcud olmadigindan telebe yaratmaq mumkun deyil. Ilk novbede qrup yaradin: \n");
                CreateGroup();
                return;
            }

            string inputGroupName;
            Group selectedGroup = null;

            do
            {
                Console.WriteLine("Telebeni hansi qrupa elave etmek isteyirsiniz? (Ana menyuya qayitmaq ucun 0 daxil edin)");
                Services.ShowAllGroups();
                inputGroupName = Console.ReadLine()?.ToUpper().Trim();

                if (inputGroupName == "0") return;

                selectedGroup = groups.FirstOrDefault(group => group.GroupNo.ToUpper() == inputGroupName);

                if (selectedGroup == null)
                {
                    Console.Clear();
                    Console.WriteLine("Bele bir qrup movcud deyil, yeniden cehd edin.\n");
                }
                else if (selectedGroup.students.Count >= selectedGroup.GroupLimit)
                {
                    Console.Clear();
                    Console.WriteLine("Qrupdaki teleblerin say limiti dolub.\n");
                    return;
                }
            } while (selectedGroup == null);

            Console.Clear();

            string name;
            bool validName = false;
            do
            {
                Console.WriteLine("Telebenin adini daxil edin (Ana menyuya qayitmaq ucun 0 daxil edin):");
                name = Console.ReadLine();

                if (name == "0") return;

                validName = !string.IsNullOrWhiteSpace(name) && name.CheckName();

                if (!validName)
                {
                    Console.Clear();
                    Console.WriteLine("Ad daxil etme formati duzgun deyil.\n");
                }
            } while (!validName);
            name = name.Capitalize();
            Console.Clear();

            string surname;
            bool validSurname = false;
            do
            {
                Console.WriteLine("Telebenin soyadini daxil edin (Ana menyuya qayitmaq ucun 0 daxil edin):");
                surname = Console.ReadLine();

                if (surname == "0") return;

                validSurname = !string.IsNullOrWhiteSpace(surname) && surname.CheckName();

                if (!validSurname)
                {
                    Console.Clear();
                    Console.WriteLine("Soyad daxil etme formati duzgun deyil.\n");
                }
            } while (!validSurname);
            surname = surname.Capitalize();
            Console.Clear();

            string zemanet = null;
            while (zemanet == null)
            {
                Console.WriteLine("Telebenin zemaneti var? (Ana menyuya qayitmaq ucun 0 daxil edin)");
                Console.WriteLine("1. Zemanetli \n2. Zemanetsiz");

                if (int.TryParse(Console.ReadLine(), out int studentChoice))
                {
                    if (studentChoice == 0) return;

                    switch (studentChoice)
                    {
                        case 1:
                            zemanet = "Zemanetli";
                            break;
                        case 2:
                            zemanet = "Zemanetsiz";
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Duzgun secim edin.\n");
                            break;
                    }
                }
            }
            Console.Clear();

            Student student = new Student(name, surname, zemanet);
            selectedGroup.students.Add(student);
            Console.WriteLine("Telebe qrupa ugurla elave olundu!\n");
        }

    }
}
