using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MovieApp.Models
{
    class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        
    
        public string Producer { get; set; }
     
        public int Duration { get; set; }
        public string Type { get; set; }
      

        public Movie()
        {

        }

        public Movie(string mn, string p, int du, string t)
        {
            this.MovieName = mn;
          
            this.Producer = p;
            
            this.Duration = du;
            this.Type = t;
        }
    }
}
