using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models
{
    public  class BookAuthor
    {

        public int bookId { get; set; }

        public Books? book { get; set; }

        public int authorId { get; set; }   

        public Author? author { get; set; }


    }
}
