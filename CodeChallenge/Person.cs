namespace CodeChallenge
{
	internal class Person
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string LastName { get; set; }
		public string CurrentRole { get; set; }
		public string Country { get; set; }
		public string Industry { get; set; }
		public string NumberOfRecommendations { get; set; }
		public string NumberOfConnections { get; set; }

		public Person(string _id, string _name, string _lastName, string _currentRole,
			string _country, string _industry, string _numberOfRecommendations, string _numberOfConnections)
		{
			this.Id = _id;
			this.Name = _name;
			this.LastName = _lastName;
			this.CurrentRole = _currentRole;
			this.Country = _country;
			this.Industry = _industry;
			this.NumberOfRecommendations = _numberOfRecommendations;
			this.NumberOfConnections = _numberOfConnections;
		}

	}

}