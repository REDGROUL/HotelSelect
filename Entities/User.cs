using System;

namespace HotelSelect.Entity
{
    public struct FullName
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
    }

    //сделать любое изменение проекта у себя и отправить мне pull request
    public class User
    {
        public long Id { get; set; }
        public int CountryId { get; set; }
        public long CityId { get; set; }
        public FullName FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
