<Query Kind="Statements">
  <Connection>
    <ID>cdaabbea-409e-4674-adec-397ac01f72b3</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>.</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <Database>StartTed-2025-Sept</Database>
    <DriverData>
      <LegacyMFA>false</LegacyMFA>
    </DriverData>
  </Connection>
  <RuntimeVersion>8.0</RuntimeVersion>
</Query>

// Question 1
ClubActivities.Where(a => a.StartDate >= new DateTime(2025,1,1) && a.CampusVenueID != (1) && a.Name != "BTech Club Meeting")
.Select(x => new
{
	x.StartDate,
	Location = x.CampusVenue.Location,
	Club = x.Club.ClubName,
	Activity = x.Name
})
.OrderBy(x => x.StartDate)
.Dump();

// Question 2
Programs.Where(p => p.ProgramCourses.Count(r => r.Required) >= 22)
.Select(x => new
{
	School = x.Schools.SchoolName,
	Program = x.ProgramName,
	RequiredCourseCount = x.ProgramCourses.Count(r => r.Required),
	OptionalCourseCount = x.ProgramCourses.Count - x.ProgramCourses.Count(r => r.Required)
})
.OrderBy(x => x.Program)
.Dump();

// Question 3
Students.Where(s => !s.StudentPayments.Any(sn => sn.StudentNumber == s.StudentNumber) && s.Countries.CountryName != "Canada")
.OrderBy(x => x.LastName)
.Select(x => new
{
	StudentNumber = x.StudentNumber,
	CountryName = x.Countries.CountryName,
	FullName = x.FirstName + ' ' + x.LastName,
	ClubMembershipCount = x.ClubMembers.Any(sn => sn.StudentNumber == x.StudentNumber) 
	? x.ClubMembers.Count(sn => sn.StudentNumber == x.StudentNumber).ToString() : "None"
})
.Dump();

// Question 4
Employees.Where(e => e.PositionID == 4 && e.ReleaseDate == null && e.ClassOfferings.Any(co => co.EmployeeID == e.EmployeeID))
.OrderByDescending(e => e.ClassOfferings.Count())
.ThenBy(e => e.LastName)
.Select(x => new
{
	ProgramName = x.Program.ProgramName,
	FullName = x.FirstName + ' ' + x.LastName,
	WorkLoad = x.ClassOfferings.Count() > 24 ? "High" : x.ClassOfferings.Count() > 8 ? "Med" : "Low"
})
.Dump();

// Question 5
Clubs
.Select(x => new 
{
	Supervisor = x.EmployeeID == null ? "Unknown" : x.Employee.FirstName + ' ' + x.Employee.LastName,
	Club = x.ClubName,
	MemberCount = x.ClubMembers.Count(),
	Activities = x.ClubActivities.Count() == 0 ? "None Schedule" : x.ClubActivities.Count().ToString()
})
.OrderByDescending(c => c.MemberCount)
.Dump();