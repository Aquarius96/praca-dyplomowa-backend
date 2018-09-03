using System;

namespace PracaDyplomowaBackend.Models.ModelsDto.User
{
    public class UserDto : DtoBase
    {
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Added { get; set; }
    }
}
