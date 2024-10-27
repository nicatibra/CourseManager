namespace CourseManagement.Models
{
    internal class Group
    {
        public List<Student> students = new List<Student>();
        public string GroupNo;
        public string Category;
        public string IsOnline;

        public byte GroupLimit;
        public Group(string groupNo, string category, string isOnline)
        {
            GroupNo = groupNo;
            Category = category;
            IsOnline = isOnline;

            if (IsOnline == "Online")
            {
                GroupLimit = 15;
            }
            else
            {
                GroupLimit = 10;
            }
        }

        public override string ToString()
        {
            return $"Group Name: {GroupNo}, Category: {Category}, Is online: {IsOnline}, Limit: {GroupLimit}";
        }
    }
}
