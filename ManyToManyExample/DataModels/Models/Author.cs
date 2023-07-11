using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models
{
    public  class Author
    {

        public int Id { get; set; }

        public string? authorname { get; set; }

        [ForeignKey(nameof(Books.id))]
        public int? bookId { get; set; }

        public ICollection<Books> books { get; set; }   
    }
}
