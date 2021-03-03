using P01_HospitalDatabase.Data;
using System;

namespace P01_HospitalDatabase
{
    class StartUp
    {
        static void Main(string[] args)
        {
            HospitalContext context = new HospitalContext();

            //.OnDelete(DeleteBehavior.Restrict); Add it to all Foreign Keys in to the tables
        }
    }
}
