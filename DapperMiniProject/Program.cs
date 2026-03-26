

using System;
using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;

//C:\Users\gowth\Downloads\PROJECTS\BRIDGELABZ\BridgeLabz_Training_CARLZEISS\DapperMiniProject\DapperMiniProject.csproj



class Program
{
    static async Task Main()
    {

        string connectionString =
    "Server=localhost\\SQLEXPRESS;Database=DapperDemo;Trusted_Connection=True;TrustServerCertificate=True;";

        using IDbConnection db = new SqlConnection(connectionString);

        db.Open();

        Console.WriteLine("Connected successfully.");

        // 🔹 EXECUTE → INSERT
        db.Execute("INSERT INTO Students (Name, Age) VALUES (@Name, @Age)",
            new { Name = "Gowthami", Age = 21 });



        // 🔹 EXECUTESCALAR → single value
        int count = db.ExecuteScalar<int>("SELECT COUNT(*) FROM Students");
        Console.WriteLine($"Total Students: {count}");


        // 🔹 QUERY → multiple row
        var students = db.Query<Student>("SELECT * FROM Students");
        Console.WriteLine("\nAll Students:");
        foreach (var s in students)
            Console.WriteLine($"{s.Id} - {s.Name}");


        // 🔹 QUERYFIRST
        var first = db.QueryFirst<Student>("SELECT * FROM Students");
        Console.WriteLine($"\nFirst: {first.Name}");


        // 🔹 QUERYFIRSTORDEFAULT
        var maybe = db.QueryFirstOrDefault<Student>(
            "SELECT * FROM Students WHERE Id=@Id", new { Id = 999 });
        Console.WriteLine($"\nFirstOrDefault: {(maybe == null ? "NULL" : maybe.Name)}");


        // 🔹 QUERYSINGLE
        var single = db.QuerySingle<Student>(
            "SELECT * FROM Students WHERE Id=@Id", new { Id = 1 });

        Console.WriteLine($"\nSingle: {single.Name}");


        // 🔹 PARAMETERS (Dynamic)
        var param = new DynamicParameters();
        param.Add("@Name", "Ram");
        param.Add("@Age", 22);

        db.Execute("INSERT INTO Students (Name, Age) VALUES (@Name, @Age)", param);



        // 🔹 PARAMETERS (List)
        var ids = new[] { 1, 2 };

        var list = db.Query<Student>(
            "SELECT * FROM Students WHERE Id IN @Ids", new { Ids = ids });

        Console.WriteLine("\nList Param:");
        foreach (var s in list)
            Console.WriteLine(s.Name);


        // 🔹 QUERYMULTIPLE
        var multi = db.QueryMultiple("SELECT * FROM Students; SELECT * FROM Courses;");
        var studentList = multi.Read<Student>();
        var courseList = multi.Read<Course>();

        Console.WriteLine("\nQueryMultiple done");



        // 🔹 ASYNC
        var asyncData = await db.QueryAsync<Student>("SELECT * FROM Students");
        Console.WriteLine($"\nAsync Count: {asyncData.AsList().Count}");



        // 🔹 TRANSACTION
        using (var transaction = db.BeginTransaction())
        {
            try
            {
                db.Execute("INSERT INTO Students (Name, Age) VALUES ('A', 20)", transaction: transaction);
                db.Execute("INSERT INTO Students (Name, Age) VALUES ('B', 25)", transaction: transaction);

                transaction.Commit();
                Console.WriteLine("\nTransaction committed");
            }
            catch
            {
                transaction.Rollback();
                Console.WriteLine("\nTransaction rolled back");
            }
        }


        // 🔹 EXECUTEREADER
        using var reader = db.ExecuteReader("SELECT * FROM Students");
        Console.WriteLine("\nExecuteReader:");
        while (reader.Read())
        {
            Console.WriteLine(reader["Name"]);
        }

        Console.WriteLine("\nDONE.");
    }
}

// 🔹 MODEL using OOPs for mapping query results to C# object. POCO class
class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}

class Course
{
    public int CourseId { get; set; }
    public string Title { get; set; }
}


