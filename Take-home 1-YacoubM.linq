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


// Question 3


// Question 4


// Question 5