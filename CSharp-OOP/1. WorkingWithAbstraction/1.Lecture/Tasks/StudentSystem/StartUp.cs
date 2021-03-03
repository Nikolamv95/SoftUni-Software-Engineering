namespace StudentSystem
{
    public class StartUp
    {
        public static void Main()
        {
            var studentData = new StudentData();
            var enine = new Engine(studentData);
            enine.Process();
        }
    }
}
