using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MovieApp.Models
{
    public class Actor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ActorId { get; set; }
        public string ActorName { get; set; }
        public int ActorMobile { get; set; }
        public string ActorEmail { get; set; }
        public string Gender { get; set; }

        public Actor()
        {

        }

        public Actor(string an, int am, string ae, string g)
        {
            this.ActorName = an;
            this.ActorMobile = am;
            this.ActorEmail = ae;
            this.Gender = g;
        }

    }
}
