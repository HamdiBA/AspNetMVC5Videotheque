//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Location
    {
        public int ID { get; set; }
        public int ArticleID { get; set; }
        public int ClientID { get; set; }
        public int UserID { get; set; }
        public System.DateTime DateLocation { get; set; }
        public System.DateTime DateRetour { get; set; }
        public string EtatLocation { get; set; }
    
        public virtual Article Article { get; set; }
        public virtual Client Client { get; set; }
        public virtual Utilisateur Utilisateur { get; set; }
    }
}