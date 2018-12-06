namespace PersonManager.FaceApi
{
   class PersonGroupGetResponse
   {
        public PersonGroupGetResponse()
        {
            PersonGroupId = "1";
            Name = "zmones";
            UserData = "?";
        }
        
      public string PersonGroupId { get; set; }
      public string Name { get; set; }
      public string UserData { get; set; }
   }
}