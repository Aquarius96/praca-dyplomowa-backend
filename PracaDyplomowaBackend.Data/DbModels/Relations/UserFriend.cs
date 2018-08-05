using PracaDyplomowaBackend.Data.DbModels.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracaDyplomowaBackend.Data.DbModels.Relations
{
    public class UserFriend
    {                        
        public User Friend1 { get; set; }
        public Guid Friend1Id { get; set; }
             
        public User Friend2 { get; set; }
        public Guid Friend2Id { get; set; }

        public bool Confirmed { get; set; }
        public DateTime Added { get; set; }
    }
}
