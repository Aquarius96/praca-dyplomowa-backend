using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PracaDyplomowaBackend.Data.DbModels
{
    public class EntityBase<T>
    {
        [Key]
        public T Id { get; set; }
    }
}
