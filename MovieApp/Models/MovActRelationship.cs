using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MovieApp.Models
{
    public class MovActRelationship
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int RelationshipId { get; set; }
        [ForeignKey(nameof(Movie))]
        public int MovieId { get; set; }
        [ForeignKey(nameof(Actor))]
        public int ActorId{ get; set; }
        public MovActRelationship(int mi,int ai)
        {
            this.MovieId = mi;
            this.ActorId = ai;
        }
        public MovActRelationship()
        {

        }
    }
}
