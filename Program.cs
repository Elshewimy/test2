using EFSchoolLab;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


using var context = new SchoolContext();

var students = context.Students.ToList();
foreach (var s in students)
{
    Console.WriteLine($"{s.Name} - {s.StudentId}");
}

var coursesWithInstructors = context.Courses
    .Include(c => c.Enrollments)
    .ThenInclude(e => e.Student)
    .Select(c => new
    {
        c.Title,
        Instructors = c.Enrollments.Select(e => e.Student.Name)
    })
    .ToList();

foreach (var c in coursesWithInstructors)
{
    Console.WriteLine($"{c.Title}: {string.Join(", ", c.Instructors)}");
}

var enrollments =
    from e in context.Enrollments
    join s in context.Students on e.StudentId equals s.StudentId
    join c in context.Courses on e.CourseId equals c.CourseId
    select new
    {
        StudentName = s.Name,
        CourseTitle = c.Title,
        e.Grade
    };

foreach (var e in enrollments)
{
    Console.WriteLine($"{e.StudentName} - {e.CourseTitle} - Grade: {e.Grade}");
}


