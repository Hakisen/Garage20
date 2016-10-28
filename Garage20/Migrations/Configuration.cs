namespace Garage20.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;


    internal sealed class Configuration : DbMigrationsConfiguration<Garage20.Models.Garage20Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Garage20.Models.Garage20Context";
        }

        protected override void Seed(Garage20.Models.Garage20Context context)
        {
            var members = new Member[] {
                new Member() { MemberName = "Arne Anka" },
                new Member() { MemberName = "Bengt Busig" },
                new Member() { MemberName = "Lisa Ledig" },
                new Member() { MemberName = "Eva Ärlig" },
                new Member() { MemberName = "Kalle Kula" },
                new Member() { MemberName = "Erik Egen" },
                new Member() { MemberName = "Enoq Värsting" },
                new Member() { MemberName = "Sara Stilig" },
                new Member() { MemberName = "Rut Rolig" },
                new Member() { MemberName = "Lasse Läskig" }
                };

            context.Members.AddOrUpdate(c => c.MemberName, members);

            var typeOfVehicle = new TypeOfVehicle[]
            {
                new TypeOfVehicle() { VehicleType = "Car" },
                new TypeOfVehicle() { VehicleType = "Truck" },
                new TypeOfVehicle() { VehicleType = "Motorcycle" },
                new TypeOfVehicle() { VehicleType = "Bus" },
                new TypeOfVehicle() { VehicleType = "Motorhome" }
            };

            context.TypeOfVehicles.AddOrUpdate(c => c.VehicleType, typeOfVehicle);
            context.SaveChanges();

            context.Vehicles.AddOrUpdate(
                s => s.RegNr,
                new Vehicle() { RegNr = "ABC123", TypeOfVehicleId = typeOfVehicle[0].Id, colour = "Red", Brand = "Volvo", Model = "S60", NrOfWheels = 4, TimeIn = DateTime.Now.AddHours(-1), MemberId = members[0].Id },
                new Vehicle() { RegNr = "ABC456", TypeOfVehicleId = typeOfVehicle[0].Id, colour = "Blue", Brand = "Saab", Model = "99", NrOfWheels = 4, TimeIn = DateTime.Now.AddHours(-1), MemberId = members[1].Id },
                new Vehicle() { RegNr = "CDE123", TypeOfVehicleId = typeOfVehicle[0].Id, colour = "Green", Brand = "BMW", Model = "M3", NrOfWheels = 4, TimeIn = DateTime.Now.AddHours(-1), MemberId = members[2].Id },
                new Vehicle() { RegNr = "DEF456", TypeOfVehicleId = typeOfVehicle[0].Id, colour = "Yellow", Brand = "Mercedes", Model = "E200", NrOfWheels = 4, TimeIn = DateTime.Now.AddHours(-1), MemberId = members[3].Id },
                new Vehicle() { RegNr = "GHJ123", TypeOfVehicleId = typeOfVehicle[1].Id, colour = "Black", Brand = "Ford", Model = "Bronco", NrOfWheels = 6, TimeIn = DateTime.Now.AddHours(-1), MemberId = members[4].Id },
                new Vehicle() { RegNr = "KLM789", TypeOfVehicleId = typeOfVehicle[2].Id, colour = "Silver", Brand = "Yamaha", Model = "125", NrOfWheels = 2, TimeIn = DateTime.Now.AddHours(-1), MemberId = members[5].Id },
                new Vehicle() { RegNr = "CDE456", TypeOfVehicleId = typeOfVehicle[3].Id, colour = "Red", Brand = "Scania", Model = "Luxury", NrOfWheels = 6, TimeIn = DateTime.Now.AddHours(-1), MemberId = members[6].Id },
                new Vehicle() { RegNr = "EFG123", TypeOfVehicleId = typeOfVehicle[4].Id, colour = "Blue", Brand = "Knaus", Model = "SuperHome", NrOfWheels = 6, TimeIn = DateTime.Now.AddHours(-1), MemberId = members[7].Id },
                new Vehicle() { RegNr = "JKL456", TypeOfVehicleId = typeOfVehicle[0].Id, colour = "Silver", Brand = "Opel", Model = "Kapitän", NrOfWheels = 4, TimeIn = DateTime.Now.AddHours(-1), MemberId = members[1].Id }
                );

            //var teacher = new Teacher();
            //teacher.Name = "Örjan Undervisare";
            //teacher.Department = "Mathemathics";
            //context.Teachers.AddOrUpdate(t => t.Name, teacher);
            //context.SaveChanges();

            //var dbTeacher = context.Teachers
            //    .Include(t => t.TaughtCourses)
            //    .Where(t => t.Id == teacher.Id)
            //    .FirstOrDefault();

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
